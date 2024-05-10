using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField[] textInputs;
    void Start()
    {
        textInputs[0].Select();
    }

    public void OnTextInputClicked(int index)
    {
        textInputs[index].Select();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (InputField inputField in textInputs)
            {
                if (inputField.isFocused)
                {
                    inputField.text += Input.inputString;
                }
            }
        }
    }
}
