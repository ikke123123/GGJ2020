using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] public PlayerType player;

    [Header("Images")]
    [SerializeField] private Image squareMarker;
    [SerializeField] private Image background;
    [SerializeField] private Image squareUnhidden;

    [Header("Spawning")]
    [SerializeField] private float speed;
    [SerializeField] private float padding;
    [SerializeField] private GameObject prefab;
    [SerializeField] public bool disabled = false;

    [Header("Fading")]
    [SerializeField] private float borderRight;
    [SerializeField] private float borderLeft;

    [Header("Checking and Destroying")]
    [SerializeField] private InputType[] inputTypes;
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    [Header("Don't Touch")]
    [SerializeField] private ButtonType[] buttons;

    [Header("Debug")]
    [SerializeField] private int difficultyLevel;
    [SerializeField] private int blocksToGo;
    [SerializeField] private Rect markerRect;
    [SerializeField] private float backgroundLeft;
    [SerializeField] private float backgroundRight;
    [SerializeField] private Vector3 spawnVector;
    [SerializeField] private Quaternion spawnQuaternion = new Quaternion(0, 0, 0, 0);
    [SerializeField] private float verticalCenter;
    [SerializeField] private List<GameObject> instantiatedImages;
    [SerializeField] private float timer;
    [SerializeField] public float speedModifier;
    [SerializeField] private float speedtimer;

    private void Awake()
    {
        timer = 0;
        GetBounds(background, ref backgroundLeft, ref backgroundRight);
        markerRect = new Rect(squareMarker.rectTransform.localPosition.x, squareMarker.rectTransform.localPosition.y, 1, squareMarker.rectTransform.rect.height);
        spawnVector = new Vector3(backgroundLeft + padding, background.rectTransform.localPosition.y, 0);
        difficultyLevel = 1;
        NewRound();
        speedtimer = 10;
    }

    private void FixedUpdate()
    {
        //Timekeeping
        if (Time.time >= timer && disabled == false)
        {
            squareMarker.gameObject.SetActive(true);
            background.gameObject.SetActive(true);
            squareUnhidden.gameObject.SetActive(true);
            //Resets the timer
            timer = Time.time + Random.Range(0.75f, 3);
            //Spawns new object
            SpawnObject();
        }
        if (Time.time > speedtimer && disabled == false)
        {
            speed = speed * (speedModifier + 1);
            speedtimer += 10;
            SetSpeed(speed);
        }
        if (player1.seizure == false && player2.seizure == false && disabled == true)
        {
            disabled = false;
            speedtimer = Time.time + 10;
        }
    }

    //GameObjects will report when the object has not been destroyed at the end
    public void ReachedEnd(GameObject input)
    {
        ActivateSeizure();
        DestroyThing(input);
    }

    public void ReportOverlap(GameObject input, InputType inputType)
    {
        List<InputType> tempInputTypes = new List<InputType>();
        tempInputTypes.AddRange(inputTypes);
        tempInputTypes.Remove(inputType);

        foreach (InputType type in tempInputTypes)
        {
            if (InputManager.Get(type, player, PressType.down))
            {
                DestroyThing(input);
                ActivateSeizure();
                return;
            }
        }

        if (InputManager.Get(inputType, player, PressType.down))
        {
            DestroyThing(input);
            GoodClick();
        }
    }

    private void DestroyThing(GameObject input)
    {
        instantiatedImages.Remove(input);
        input.GetComponent<FadeManager>().selfDestruct = true;
    }

    //To Do When Succeeds
    private void GoodClick()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Hammer");
        if (blocksToGo == 0)
        {
            difficultyLevel++;
            NewRound();
        }
        else
        {
            blocksToGo--;
        }
    }

    //To Do When It Fails
    private void BadClick()
    {

    }

    private void SetSpeed(float input)
    {
        foreach (GameObject gameobject in instantiatedImages)
        {
            gameobject.GetComponent<ImageSpeed>().speed.x = input;
        }
    }

    private void NewRound()
    {
        blocksToGo = difficultyLevel * 5;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Success");
    }

    private void ActivateSeizure()
    {
        BadClick();
        DestroyAllObjects();
        disabled = true;
        squareMarker.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
        squareUnhidden.gameObject.SetActive(false);
        if (player == PlayerType.Player1)
        {
            player1.seizure = true;
            return;
        }
        player2.seizure = true;
    }

    private void DestroyAllObjects()
    {
        GameObject[] gameObjects = instantiatedImages.ToArray();
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].GetComponent<FadeManager>().selfDestruct = true;
            Destroy(gameObjects[i]);
        }
        instantiatedImages.Clear();
    }

    private void GetBounds(Image input, ref float leftBound, ref float rightBound)
    {
        float inputLocation = input.gameObject.GetComponent<RectTransform>().localPosition.x;
        float inputWidth = input.gameObject.GetComponent<RectTransform>().rect.size.x;
        leftBound = inputLocation - inputWidth * 0.5f;
        rightBound = inputLocation + inputWidth * 0.5f;
    }

    public void SpawnObject()
    {
        int randomNum = Random.Range(0, buttons.Length);

        GameObject tempGameObject = Instantiate(prefab, transform);
        tempGameObject.GetComponent<RectTransform>().localPosition = spawnVector;
        tempGameObject.GetComponent<RectTransform>().localRotation = spawnQuaternion;

        tempGameObject.GetComponent<Image>().sprite = buttons[randomNum].sprite;

        tempGameObject.GetComponent<ImageSpeed>().speed.x = speed;

        ImageReporting tempImageReporting = tempGameObject.GetComponent<ImageReporting>();
        tempImageReporting.rect = markerRect;
        tempImageReporting.maxX = backgroundRight;
        tempImageReporting.minX = backgroundLeft;
        tempImageReporting.imageManager = this;
        tempImageReporting.inputType = buttons[randomNum].inputType;



        FadeManager tempFadeManager = tempGameObject.AddComponent<FadeManager>();
        tempFadeManager.stopFadeX = spawnVector.x + borderLeft;
        tempFadeManager.startFadeX = backgroundRight - borderRight;
        tempFadeManager.fadeEndStop = backgroundRight;

        instantiatedImages.Add(tempGameObject);
    }
}

[System.Serializable]
public class ButtonType
{
    [SerializeField] public InputType inputType;
    [SerializeField] public Sprite sprite;
}