using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlightMovement : MonoBehaviour
{
    public TMP_InputField radiusInputField;  
    public Button startButton;           
    public Transform cameraTransform;    

    private float radius = 5f;          
    private float duration = 5f;        
    private float rotationSpeed;         
    private bool isMoving = false;       
    private float elapsedTime = 0f;      

    void Start()
    {
       
        startButton.onClick.AddListener(StartCircularMovement);
    }

    void Update()
    {
        if (isMoving)
        {
           
            if (elapsedTime < duration)
            {
                
                transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
                transform.LookAt(Vector3.zero);
                //if (cameraTransform != null)
                //{
                //    cameraTransform.position = transform.position - transform.forward * 15f + Vector3.up * 5f;
                //    cameraTransform.LookAt(transform.position + transform.forward * 5f);
                //}
                elapsedTime += Time.deltaTime;
            }
            else
            {
                
                isMoving = false;
            }
        }
    }

    public void StartCircularMovement()
    { 
        if (float.TryParse(radiusInputField.text, out float userRadius))
        {
            radius = Mathf.Abs(userRadius); 
            transform.position = new Vector3(radius, 0, 0);
            rotationSpeed = 360f / duration; 
            elapsedTime = 0f;
            isMoving = true;
        }
    }
}
 