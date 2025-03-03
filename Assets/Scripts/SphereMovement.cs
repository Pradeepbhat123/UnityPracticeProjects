using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour
{
    public GameObject sphere; 
    public GameObject plane;   
    public TMP_InputField inputX; 
    public TMP_InputField inputY; 
    public Button okButton;    

    void Start()
    {
        
        okButton.onClick.AddListener(MoveSphere);
    }

    void MoveSphere()
    {
        float inputXValue = float.Parse(inputX.text);
        float inputYValue = float.Parse(inputY.text);

       
        float planeWidth = plane.transform.localScale.x; 
        float planeHeight = plane.transform.localScale.z;

        float targetX = (inputXValue * planeWidth) / 2;
        float targetZ = (inputYValue * planeHeight) / 2;

        if(Mathf.Abs(inputXValue)<= planeWidth && Mathf.Abs(inputYValue)<= planeHeight)
        {
          sphere.transform.position =     
          new Vector3(targetX+plane.transform.position.x, sphere.transform.position.y, targetZ+plane.transform.position.z);


        }
        else
        {
            Debug.Log("Enter valid co-ordinates");
        }
    }
}