using UnityEngine;
using System.Collections;
public class ElevatorAndFlapController : MonoBehaviour
{
    public Transform RightElevator, LeftElevator; 
    public Transform RightFlap, LeftFlap;        
    public float elevatorRotationSpeed = 1f; 
    public float flapRotationSpeed = 1f;     

    private int elevatorCounter = 0;         
    private int flapCounter = 0;             
    private int maximumRotation = 30;      
    private bool flapReversing = false;      

    private void Start()
    {
        StartCoroutine(ElevatorMovement(RightElevator, 1));
        StartCoroutine(ElevatorMovement(LeftElevator, -1)); 
        StartCoroutine(FlapMovement());
    }

    private IEnumerator ElevatorMovement(Transform elevator, int role)
    {
        int counter = 0; 
        float rotationSpeed = elevatorRotationSpeed * role; 

        while (true)
        {
            yield return null;
            elevator.Rotate(new Vector3(rotationSpeed, 0, 0));
            counter += role; 
            if (Mathf.Abs(counter) == maximumRotation)
            {
                rotationSpeed = -rotationSpeed; 
            }
        }
    }

    private IEnumerator FlapMovement()
    {
        while (true)
        {
            yield return null;
            float currentRotation = flapReversing ? -flapRotationSpeed : flapRotationSpeed;

            RightFlap.Rotate(new Vector3(currentRotation, 0, 0));
            LeftFlap.Rotate(new Vector3(currentRotation, 0, 0));
            flapCounter += flapReversing ? -1 : 1;

            if (Mathf.Abs(flapCounter) == maximumRotation)
            {
                flapReversing = !flapReversing; 
            }
        }
    }
}
