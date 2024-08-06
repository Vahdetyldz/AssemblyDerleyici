using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompilerConsole : MonoBehaviour
{
    private InputField _inputField;
    public Color textColorRed = Color.red;
    public Color textColorBlack = Color.black;

    void Start()
    {
        _inputField = GetComponent<InputField>();
    }

    public void SetInputFieldData(string data)
    {
        _inputField.text = data;
    }
    public void SetInputFieldColor(string color)
    {
        switch (color)
        {
            case "red":
                _inputField.textComponent.color = textColorRed;
                break;
            case "black":
                _inputField.textComponent.color = textColorBlack;
                break;
        }
        
    }
}
