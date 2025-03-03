using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ViewModes : MonoBehaviour
{
    [SerializeField] TMP_Dropdown viewmodesDropdown;
    [SerializeField] GameObject drone;
    [SerializeField] CinemachineVirtualCamera flightCam;
    [SerializeField] GameObject panel;
    [SerializeField] ScrollRect ScrollViewMessageBox;
    public TextMeshProUGUI messageText;
    public Button Target;
   //public Button button;
   
    void Start()
    {
        
        viewmodesDropdown.onValueChanged.AddListener(DropdownSelect);
       
    }

    public void DropdownSelect(int index)
    {
        viewmodesDropdown.value = index;
        switch (index)
        {
            case 0: //Home View
              
                flightCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0.15f, 14.99f, 6.4f);
                break;

            case 1:
                flightCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(-0.05f,2.2f,9.76f); // Offset for Back View
                break;
            case 2: //Top View
             
                flightCam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0.45f, 16.19f, 9.76f);
                break;

        }
    }
  
    public void TargetSet()
    {
        messageText.text += "\nTarget is set at Time " + System.DateTime.Now.ToString("HH:mm, dd MMM yyyy") +
                     " \nLatitude 40.7128, Longitude -74.0060"; 
        Canvas.ForceUpdateCanvases();
        ScrollViewMessageBox.verticalNormalizedPosition = 0f;
        Target.interactable=false;
    }
    
}
