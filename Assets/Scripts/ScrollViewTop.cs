using UnityEngine;
using UnityEngine.UI;

public class ScrollViewTop : MonoBehaviour
{
    public Transform contentParent;
    private int count = 1; 

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMessage($"Flight take off " + count);
            count++;
        }
    }

    void AddMessage(string message)
    {
       
        GameObject newMessage = new GameObject("Message");
        Text textComponent = newMessage.AddComponent<Text>();
        textComponent.text = message;
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.color = Color.black; 
        textComponent.alignment = TextAnchor.MiddleCenter; 
        newMessage.transform.SetParent(contentParent, true);
        newMessage.transform.SetAsFirstSibling();
    }
}