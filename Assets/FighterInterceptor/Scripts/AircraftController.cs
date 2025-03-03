using UnityEngine;
using System.Collections;

public class AircraftController : MonoBehaviour
{
    public float speed = 5f; 
    private bool loop = false;
    private bool turn = false;
   //public Transform cam;
    public void PerformLoopManeuver()
    {
        if (!loop)
            StartCoroutine(LoopManeuver());
    }

    public void PerformTurnManeuver()
    {
        if (!turn)
            StartCoroutine(TurnManeuver());
    }

    private IEnumerator LoopManeuver()
    {
        loop = true;
        float angle = 0f;
       //Vector3 center = transform.position + (-transform.right * 15f);
        while (angle < 360f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.Rotate(Vector3.left, 2f); 
           // transform.RotateAround(center, Vector3.right, 2f);
            angle += 2f;
            yield return null;
        }

        //transform.rotation = Quaternion.identity;
        //transform.position = new Vector3(15.16f, -97.82f, -24.14f);
        loop = false;

    }

    private IEnumerator TurnManeuver()
    {
        
        turn = true;
        float turnAngle = 0f;
        float rollAngle = 0f; 
        float rollDirection = 1f;
        bool rollRotation = false;
        while (turnAngle < 180f)
        {
            
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.Rotate(Vector3.up, 2f);
            turnAngle += 2f;
            if (turnAngle <= 90f)
            {
                
                if (rollAngle < 30f)
                {
                    transform.Rotate(Vector3.forward, 1f * rollDirection);
                    rollAngle += 1f;
                  
                }
                
            }
            else
            {
                if(rollRotation == true) { 
                if (rollAngle > 0f)
                {
                    transform.Rotate(Vector3.forward, -1f * rollDirection);
                    rollAngle -= 1f; 
                        
                }
                    
                }
            }
            yield return null;
        }
        turn = false;

    }

}