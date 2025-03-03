using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public Transform target; 
    public float speed = 5f;
    public GameObject Aircraft;
    public float rotationSpeed = 50f;
    [SerializeField] private ParticleSystem particleEffect;

    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        Vector3 directionToTarget=(target.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f );
        rb.velocity=transform.forward*speed;
       

    }  
    private void OnCollisionEnter(Collision c)
    {
        Debug.Log("Collision detected with: " +c.gameObject.name);
        ParticleSystem fire = Instantiate(particleEffect, Aircraft.transform.position, Quaternion.identity);
        fire.Play();
        Destroy(fire.gameObject, 3f);
        Destroy(Aircraft, 3f);
    }
   

}