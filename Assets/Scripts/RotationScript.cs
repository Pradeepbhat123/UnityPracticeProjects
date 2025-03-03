using System.Collections;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private float maxDeflection = 30f;
    private float perFrameRotation = 0.1f;
    private float rotationCounter;
    private int rotationDirection = 1;

    private void Start()
    {
        //transform.rotation = Quaternion.Euler(new Vector3(-maxDeflection, 0, 0));
        rotationCounter = 0;
        StartCoroutine(GradualRotate());
    }

    private IEnumerator GradualRotate()
    {
        while (true)
        {
            yield return null;
            rotationCounter += perFrameRotation;
            transform.Rotate(perFrameRotation * rotationDirection, 0, 0);

            if (rotationCounter > 2 * maxDeflection)
            {
                rotationDirection *= -1;
                rotationCounter = 0;
            }
        }
    }
}
