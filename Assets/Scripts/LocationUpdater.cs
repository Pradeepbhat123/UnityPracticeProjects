//when the object above the ground or below the ground ,to find raycast distance
using CesiumForUnity;
using System.Collections;
using TMPro;
using UnityEngine;

public class LocationUpdater : MonoBehaviour
{
    public CesiumGeoreference cesiumGeoreference;
    public Cesium3DTileset tileset;
    public GameObject referenceObject;
    public TMP_InputField latitudeInput;
    public TMP_InputField longitudeInput;

    private string latString;
    private string lonString;

    public void latValueChanges(string convertedLat)
    {
        latString = convertedLat;
    }

    public void lonValueChanges(string convertedLon)
    {
        lonString = convertedLon;
    }

    public void ButtonChange()
    {
        double originLat = double.Parse(latString);
        double originLon = double.Parse(lonString);
        cesiumGeoreference.SetOriginLongitudeLatitudeHeight(originLon, originLat, cesiumGeoreference.height);

        StartCoroutine(WaitForTilesetLoad());
    }

    private IEnumerator WaitForTilesetLoad()
    {
        while (tileset.ComputeLoadProgress() < 1f)
        {
            yield return null;
        }
        Debug.Log("Map Loading Finished");
        Ray ray = new Ray(referenceObject.transform.position, Vector3.down);
        float rayDistance = 2000f;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayDistance))
        {
            Debug.Log("HIT");
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.red);

            float referenceObjectHeight = referenceObject.transform.position.y;
            if (referenceObjectHeight < hitInfo.point.y)
            {
                cesiumGeoreference.height -= (1000 - hitInfo.distance);
                Debug.Log($"Height from object to ground: {1000 - hitInfo.distance} meters");
            }
            else
            {
                cesiumGeoreference.height += (1000-hitInfo.distance);
                Debug.Log($"Height from object to ground: {hitInfo.distance} meters");
            }
        }
        else
        {
            Debug.Log("No hit detected.");
        }
    }   
}
