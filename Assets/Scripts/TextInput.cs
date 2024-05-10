using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInput : MonoBehaviour
{
    private TMP_InputField _inputField;
    public TMP_Text displayText;

    private string _lineSymbol = "-)";
    private int _lineCount;
    public Color lineNumberColor;
    void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        //Create first line.
        CreateLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputField.isFocused)
        {
            EnterKeyState();
        }
        SetCaretPositionToDefault();
        //AdjustCaretPosition();
        //OnInputValueChanged();
        //ResetCaretPositionToDefault(_lineCount.ToString().Length + _lineSymbol.Length + displayText.text.Length + 1);
    }

    public void EnterKeyState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CreateLine();
        }
    }

    public void CreateLine()
    {
        //Update line count.
        _lineCount = _inputField.text.Split('\n').Length;
        var lineIndex = _lineCount.ToString() + _lineSymbol;

        _inputField.text += lineIndex;

        //Update caret position.
        _inputField.caretPosition += _lineSymbol.Length + _lineCount.ToString().Length;
    }

    private void SetCaretPositionToDefault()
    {
        // Get the current caret position
        int caretPosition = _inputField.caretPosition;

        // Get the text until the caret position
        string textUntilCaret = _inputField.text.Substring(0, caretPosition);

        int lineNumber = 1;

        // Geriye doðru imlecin olduðu satýrýn baþýna kadar git
        for (int i = caretPosition - 1; i >= 0; i--)
        {
            // Eðer bulunduðumuz karakter '\n' ise (yani satýrbaþý ise), lineNumber'ý arttýr
            Debug.Log("1.for ");
            int num=0;
            if (textUntilCaret[i] == '-')
            {
                Debug.Log("1.if ");
                for (int k = i; textUntilCaret[i] != '\n'; k--)
                {
                    num++;
                }
                break;
            }
            Debug.Log("Num : "+ num);
            //       \n100-)asfdasf
            // Eðer bulunduðumuz karakter '-' ise, döngüyü sonlandýr
            
        }

        Debug.Log("Caret is on line: " + lineNumber);
    }

    public void ResetCaretPositionToDefault(int value)
    {
        Debug.Log("caretPosition" + value);

        if (_inputField.caretPosition < value)
        {
            _inputField.caretPosition = value;
        }
    }
    private void AdjustCaretPosition()
    {
        // Get the current caret position
        int caretPosition = _inputField.caretPosition;

        // Get the number of characters before the caret on the current line
        int lineStartIndex = GetLineStartIndex(_inputField.text, caretPosition);
        int charsBeforeCaret = caretPosition - lineStartIndex;

        // Check if the caret is within the restricted range
        if (charsBeforeCaret <= _lineCount.ToString().Length + _lineSymbol.Length)
        {
            // Adjust caret position to just after the restricted range
             _inputField.caretPosition = lineStartIndex + _lineCount.ToString().Length + _lineSymbol.Length + 1;
        }
    }
    private int GetLineStartIndex(string text, int caretPosition)
    {
        // Find the start index of the current line
        int lineStartIndex = 0;
        for (int i = caretPosition - 1; i >= 0; i--)
        {
            if (text[i] == '\n')
            {
                lineStartIndex = i + 1;
                break;
            }
        }
        Debug.Log("AA:" + lineStartIndex);
        return lineStartIndex;
    }
}
