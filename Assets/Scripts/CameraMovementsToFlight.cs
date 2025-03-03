using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementsToFlight : MonoBehaviour
{
    public Transform Aircraft;
    public Transform camera1;
    //public Vector3 offset = new Vector3(0, 50, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Aircraft != null)
        {

            Vector3 newPosition = camera1.position + Aircraft.position;
            camera1.transform.position = newPosition;


        }
    }
}
