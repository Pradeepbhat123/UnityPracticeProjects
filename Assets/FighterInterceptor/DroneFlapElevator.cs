using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFlapElevator : MonoBehaviour
{
    public Transform RightElevator;
    public Transform LeftElevator;
    public Transform RightFlap;
    public Transform LeftFlap;

    private float maxDeflection = 30f; 
    private float perFrameRotation = 0.2f;
    private float currentElevatorRotation = -30f; 
    private float currentFlapRotation = -30f; 
    private int rotationDirection = 1;

    
    void Start()
    {
        RightElevator.localRotation = Quaternion.Euler(new Vector3(currentElevatorRotation, 0, 0));
        LeftElevator.localRotation = Quaternion.Euler(new Vector3(currentElevatorRotation, 0, 0));
        RightFlap.localRotation = Quaternion.Euler(new Vector3(currentFlapRotation, 0, 0));
        LeftFlap.localRotation = Quaternion.Euler(new Vector3(currentFlapRotation, 0, 0));
        StartCoroutine(RotateElevator());
        StartCoroutine(RotateFlap());
    }

    private IEnumerator RotateElevator()
    {
        while (true)
        {
            yield return null;
            currentElevatorRotation += perFrameRotation * rotationDirection;

            RightElevator.localRotation = Quaternion.Euler(new Vector3(currentElevatorRotation, 0, 0));
            LeftElevator.localRotation = Quaternion.Euler(new Vector3(currentElevatorRotation, 0, 0));

            if (currentElevatorRotation >= maxDeflection || currentElevatorRotation <=  -maxDeflection)
            {
                rotationDirection *= -1; 
            }
        }
    }

    private IEnumerator RotateFlap()
    {
        while (true)
        {
            yield return null;
            currentFlapRotation += perFrameRotation * rotationDirection;
            RightFlap.localRotation = Quaternion.Euler(new Vector3(currentFlapRotation, 0, 0));
            LeftFlap.localRotation = Quaternion.Euler(new Vector3(-currentFlapRotation, 0, 0)); 
            if (currentFlapRotation >= maxDeflection || currentFlapRotation <= -maxDeflection)
            {
                rotationDirection *= -1; 
            }
        }
    }
}
