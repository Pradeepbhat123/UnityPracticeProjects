using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDrawLine : MonoBehaviour
{
    public GameObject spherePrefab;  
    private List<GameObject> spawnedSpheres = new List<GameObject>(); 
    private LineRenderer lineRenderer;

    private float lastClickTime = 0f;
    private float doubleClickThreshold = 0.3f;  
    void Start()
    {
        
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.endColor = Color.blue;
        lineRenderer.startColor = Color.blue;
        lineRenderer.positionCount = 0;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                SpawnSphere();
                UpdateLine();
        }
    }

    void SpawnSphere()
    {
        Vector3 spawnPosition = GetMouseWorldPosition();
        GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        spawnedSpheres.Add(newSphere); 
    }

    void UpdateLine()
    {
        if (spawnedSpheres.Count < 2) return;

        lineRenderer.positionCount = spawnedSpheres.Count;


        for (int i = 0; i < spawnedSpheres.Count; i++)
        {
            lineRenderer.SetPosition(i, spawnedSpheres[i].transform.position);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
