using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private PlayerType player;

    [Header("Images")]
    [SerializeField] private Image squareMarker;
    [SerializeField] private Image background;

    [Header("Spawning")]
    [SerializeField] private float spawnTime;
    [SerializeField] private float speed;
    [SerializeField] private float padding;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool disabled = false;

    [Header("Fading")]
    [SerializeField] private float borderRight;
    [SerializeField] private float borderLeft;

    [Header("Checking and Destroying")]
    [SerializeField] private Movement
    [SerializeField] private InputType[] keysAllowed;

    //[Header("Playability Settings")]
    //[SerializeField] private 

    [Header("Don't Touch")]
    [SerializeField] private Buttons[] buttons;

    [Header("Debug")]
    [SerializeField] private float difficultyLevel;
    [SerializeField] private Rect markerRect;
    [SerializeField] private float backgroundLeft;
    [SerializeField] private float backgroundRight;
    [SerializeField] private Vector3 spawnVector;
    [SerializeField] private Quaternion spawnQuaternion = new Quaternion(0, 0, 0, 0);
    [SerializeField] private float verticalCenter;
    [SerializeField] private ButtonType[] selectedOption;
    [SerializeField] private List<InstantiatedImage> instantiatedImages;
    [SerializeField] private float timer;

    private void Awake()
    {
        timer = 0;
        GetBounds(background, ref backgroundLeft, ref backgroundRight);
        SelectButtons();
        markerRect = new Rect(squareMarker.rectTransform.localPosition.x, squareMarker.rectTransform.localPosition.y, 1, squareMarker.rectTransform.rect.height);
        spawnVector = new Vector3(backgroundLeft + padding, background.rectTransform.localPosition.y, 0);

        Debug.Log(RectOverlap(squareMarker.rectTransform, markerRect));
    }

    private void FixedUpdate()
    {
        //Timekeeping
        if (Time.time >= timer && disabled == false)
        {
            //Resets the timer
            timer += spawnTime;
            //Spawns new object
            instantiatedImages.Add(SpawnObject(transform, selectedOption));
        }
    }

    //GameObjects will report when the object has not been destroyed at the end
    public void ReachedEnd(GameObject input)
    {

    }

    public void ReportOverlap(GameObject input, InputType inputType)
    {
        //if ()
        //{

        //}
    }

    private float AlphaCalculator(float locationX, float borderL, float borderR, float maxRight)
    {
        if (locationX >= borderL)
        {
            if (locationX <= borderR) return 1;
            return CodeLibrary.Remap(locationX, borderR, maxRight, 0, 1);
        }
        return CodeLibrary.Remap(locationX, 0, borderL, 0, 1);
    }

    private void GetBounds(Image input, ref float leftBound, ref float rightBound)
    {
        float inputLocation = input.gameObject.GetComponent<RectTransform>().localPosition.x;
        float inputWidth = input.gameObject.GetComponent<RectTransform>().rect.size.x;
        leftBound = inputLocation - inputWidth * 0.5f;
        rightBound = inputLocation + inputWidth * 0.5f;
    }

    private void SelectButtons()
    {
        foreach (Buttons button in buttons)
        {
            if (button.player == player)
            {
                List<ButtonType> tempButtonType = new List<ButtonType>();
                foreach (ButtonType buttonType in button.buttonTypes)
                {
                    tempButtonType.Add(buttonType);
                }
                selectedOption = tempButtonType.ToArray();
                return;
            }
        }
        Debug.LogError("Error, this shouldn't happen.");
    }

    private bool RectOverlap(RectTransform input, Rect rectangle)
    {
        Rect rect1 = new Rect(input.localPosition.x, input.localPosition.y, input.rect.width, input.rect.height);
        return rect1.Overlaps(rectangle);
    }

    public InstantiatedImage SpawnObject(Transform parent, ButtonType[] buttonTypes)
    {
        int randomNum = Random.Range(0, buttonTypes.Length);

        GameObject tempGameObject = Instantiate(prefab, parent);
        tempGameObject.GetComponent<RectTransform>().localPosition = spawnVector;
        tempGameObject.GetComponent<RectTransform>().localRotation = spawnQuaternion;

        tempGameObject.GetComponent<Image>().sprite = buttonTypes[randomNum].sprite;

        tempGameObject.GetComponent<ImageSpeed>().speed.x = speed;

        ImageReporting tempImageReporting = tempGameObject.GetComponent<ImageReporting>();
        tempImageReporting.rect = markerRect;
        tempImageReporting.maxX = borderRight;
        tempImageReporting.minX = borderLeft;
        tempImageReporting.imageManager = this;
        

        FadeManager tempFadeManager = tempGameObject.AddComponent<FadeManager>();
        tempFadeManager.stopFadeX = spawnVector.x + borderLeft;
        tempFadeManager.startFadeX = backgroundRight - borderRight;
        tempFadeManager.fadeEndStop = backgroundRight;

        InstantiatedImage tempInstantiatedImage = new InstantiatedImage
        {
            gameObject = tempGameObject,
            inputType = buttonTypes[randomNum].inputType
        };
        return tempInstantiatedImage;
    }
}

[System.Serializable]
public class Buttons
{
    [SerializeField] public PlayerType player;
    [SerializeField] public ButtonType[] buttonTypes;
}

[System.Serializable]
public class ButtonType
{
    [SerializeField] public InputType inputType;
    [SerializeField] public Sprite sprite;
}

[System.Serializable]
public class InstantiatedImage
{
    [SerializeField] public GameObject gameObject;
    [SerializeField] public InputType inputType;
}