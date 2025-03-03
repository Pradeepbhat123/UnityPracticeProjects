using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControlSurface : MonoBehaviour
{
    public Transform RightElevator, LeftElevator;
    public Transform RightFlap, LeftFlap;
    public Transform RightRudder, LeftRudder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float roll=DroneDataGenerator.instance.roll;
        float yaw=DroneDataGenerator.instance.yaw;
        float pitch=DroneDataGenerator.instance.pitch;

    }

}

