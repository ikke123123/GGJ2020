using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeLibrary : MonoBehaviour
{
    //------------------------------------------
    //             Made By Thomas
    //------------------------------------------
    //All kinds of useful, and less useful code things

    //Add random color
    //Add random rotation
    //Add random position within two vectors
    //Add getting average
    //Add getting median
    //Remapping values (if value is 2 on a scale from 1 to 10 and you want to remap it to 1 to 20 it would be 4)
    //Delete stuff from foreach loop

    public static bool RectOverlap(RectTransform input, Rect rectangle)
    {
        Rect rect1 = new Rect(input.localPosition.x, input.localPosition.y, input.rect.width, input.rect.height);
        return rect1.Overlaps(rectangle);
    }

    public static float Remap(float input, float minCurrent, float maxCurrent, float minNew, float maxNew)
    {
        return Mathf.Clamp((input - minCurrent) * (maxNew - minNew) / maxCurrent + minNew, minNew, maxNew);
    }

    public static Vector3 MaxVector3Size()
    {
        return new Vector3 { x = 10000, y = 10000, z = 10000 };
    }

    public static void RemoveParents(Transform transformInput)
    {
        foreach (Transform transform in transformInput)
        {
            RemoveParents(transform);
            transform.parent = null;
        }
    }

    public static Quaternion AddToQuaternion(Quaternion input1, Quaternion input2)
    {
        return new Quaternion(input1.w + input2.w, input1.x + input2.x, input1.y + input2.y, input1.z + input2.z);
    }

    public static Vector3 ScaleVector3Sum(Vector3 input, float sum)
    {
        Vector3 output;
        output.x = input.x + sum;
        output.y = input.y + sum;
        output.z = input.z + sum;
        return output;
    }

    public static Vector3 ScaleVector3Modifier(Vector3 input, float modifier)
    {
        Vector3 output;
        output.x = input.x * modifier;
        output.y = input.y * modifier;
        output.z = input.z * modifier;
        return output;
    }

    /// <summary>
    /// Replaces the Game Object with another Game Object, with the same velocity and positition.
    /// </summary>
    /// <param name="replace"></param>
    /// <param name="with"></param>
    public static void ReplaceObject(GameObject replace, GameObject with)
    {
        GameObject tempObject = Instantiate(with, replace.transform.position, replace.transform.rotation);
        if (replace.GetComponent<Rigidbody>() == false) return;
        if (tempObject.GetComponent<Rigidbody>() == false) tempObject.AddComponent<Rigidbody>();
        MatchSpeed(tempObject.GetComponent<Rigidbody>(), replace.GetComponent<Rigidbody>());
        Destroy(replace);
    }

    public static void MatchSpeed(Rigidbody subject, Rigidbody matchedTo)
    {
        subject.velocity = matchedTo.velocity;
        subject.angularVelocity = matchedTo.angularVelocity;
    }

    public static void ResizeBoxColliderToMeshFilter(BoxCollider collider, MeshFilter mesh)
    {
        collider.size = mesh.mesh.bounds.size;
        collider.center = mesh.mesh.bounds.center;
    }

    public static void IncrementalIncrease(ref int input, int increment, int max, int min = 0)
    {
        input += increment;
        if (input > max) input = min;
        if (input < min) input = max;
    }

    public static void ResizeSphereColliderToMesh(SphereCollider collider, MeshFilter mesh)
    {
        collider.radius = GetHighestOfVector3(mesh.mesh.bounds.extents);
        collider.center = mesh.mesh.bounds.center;
    }

    public static float GetHighestOfArray(float[] array)
    {
        float output = 0;
        foreach (float floatyNumber in array)
        {
            SetIfHigher(ref output, floatyNumber);
        }
        return output;
    }

    public static float GetHighestOfVector3(Vector3 input)
    {
        float output = input.x;
        SetIfHigher(ref output, input.y);
        SetIfHigher(ref output, input.z);
        return output;
    }

    public static bool SetIfHigher(ref float var, float higherThan)
    {
        if (var > higherThan)
        {
            var = higherThan;
            return true;
        }
        return false;
    }

    public static bool CheckForSameBools(bool[] booleans, bool whatToLookFor)
    {
        int multipleCount = 0;
        foreach (bool boolyBit in booleans)
        {
            if (boolyBit == whatToLookFor)
            {
                multipleCount++;
                if (multipleCount == 2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static void SetVelocity(Rigidbody rb, float x = 0, float y = 0, float z = 0)
    {
        rb.velocity = new Vector3(x, y, z);
    }

    public static float ReturnBiggest(float input1, float input2)
    {
        if (input1 > input2)
        {
            return input1;
        }
        return input2;
    }

    public static float ReturnSmallest(float input1, float input2)
    {
        if (input1 < input2)
        {
            return input1;
        }
        return input2;
    }

    public static float ReverseBROKEN(float input, float scale = 1)
    {
        return (input - 1) * -1;
    }

    public static float Reverse(float input, float minCurrent, float maxCurrent, float desiredScale)
    {
        return (input - (maxCurrent - minCurrent)) * desiredScale;
    }

    public static bool CheckSameObjectType(object input1, object input2)
    {
        if (input1.GetType() == input2.GetType())
        {
            return true;
        }
        return false;
    }

    public static bool BetweenTwoValues(float input, float min, float max)
    {
        if (input < min && input > max)
        {
            return false;
        }
        return true;
    }

    public static bool ContainsObject(object[] input, object checkFor)
    {
        if (input.GetType() != checkFor.GetType()) return false;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == checkFor) return true;
        }
        return false;
    }

    public static Color ConvertToTransparent(Color input, float alpha)
    {
        return new Color(input.r, input.g, input.b, alpha);
    }
}