using UnityEngine;
using CesiumForUnity;

public class EmergencyLanding : MonoBehaviour
{
    public CesiumGeoreference cesiumGeoreference;
    public Transform airplane;
    public float landingSpeed = 0.1f; 
    private Vector3 targetPosition;
    private bool isLanding = false;

    public void TriggerEmergencyLanding()
    {
        Debug.Log("emergency2");
        if (cesiumGeoreference == null || airplane == null) return;

      
        double targetLat = 39.737;
        double targetLon = -105.2587;
        double targetHeight = cesiumGeoreference.height; 

        cesiumGeoreference.SetOriginLongitudeLatitudeHeight(targetLon, targetLat, targetHeight);
    }

   //unity ui extensions ui line renderer
   
}
