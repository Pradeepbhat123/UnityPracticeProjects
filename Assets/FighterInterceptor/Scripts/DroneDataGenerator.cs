using System.Collections;
using UnityEngine;

public class DroneDataGenerator : MonoBehaviour
{
    public static DroneDataGenerator instance;

    public float roll;
    public float pitch;
    public float yaw;

    public float maxRoll = 30f;
    public float maxPitch = 30f;
    public float maxYaw = 30f;

    [SerializeField] private float generateDelay = 0.5f;
    [SerializeField] private float smoothSpeed = 0.5f;
    private void Start()
    {
        instance= this; 
        StartCoroutine(GenerateData());

    }
        private IEnumerator GenerateData()
    {
        yield return null;

        
        }
    }
