using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
       
        changeButtonColor();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void changeButtonColor()
    {
        button = GetComponent<Button>();
        TextMeshProUGUI buttonText = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonText.text = "hello";
        ColorBlock colors = button.colors;
        colors.normalColor = Color.blue;
        button.colors = colors;
    }
}
