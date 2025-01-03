using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    private int _lineNumber;
    public Color textColorRed = Color.red;
    public Color textColorBlack = Color.black;
    public int lineNumber 
    { 
        get => _lineNumber;
        set => _lineNumber = value;
    }

    public Text lineNumberText;

    public InputField _inputField;
    private void Start()
    {
        lineNumberText.text = _lineNumber + "-)";
    }
    public string GetData()
    {
        return _inputField.text;
    }
    public void SetData(string data)
    {
        _inputField.text = data;
    }
    public void SetTextColor(string color)
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