using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{
     RaycastHit hit;
    public int DistanceTravel = 100;
    Ray ray;
     //[SerializeField]LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    ray.origin=transform.position;
        ray.direction=Vector3.forward;
        Physics.Raycast(ray, out hit, DistanceTravel);
        Debug.DrawRay(ray.origin,ray.direction,Color.green,Time.deltaTime);
    }
}
