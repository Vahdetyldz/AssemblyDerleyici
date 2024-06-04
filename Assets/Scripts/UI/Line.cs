using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    private int _lineNumber;
    public int lineNumber 
    { 
        get => _lineNumber;
        set => _lineNumber = value;
    }

    public Text lineNumberText;
    public Text dataText;
    private void Start()
    {
        lineNumberText.text = _lineNumber + "-)";
    }
    public string GetData()
    {
        return dataText.text;
    }
}