using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    private Line _linePrefab;
    [SerializeField]
    private Transform _linesGroup;
    [SerializeField]
    private int _initialLineCount;

    public List<Line> _lines = new List<Line>();
    int cnt = 0;
    private void Start()
    {
        // Add initial lines to list.
        AddLine(_initialLineCount);
    }

    private void Update()
    {
        EnterState();
        DeleteState();
        if (_lines.Count > 0 && cnt < 3)
        {
            InputField firstInputField = _lines[0].GetComponentInChildren<InputField>();
            if (firstInputField != null)
            {
                StartCoroutine(SelectInputField(firstInputField));
            }
            cnt++;
        }
    }

    public void EnterState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
            if (currentSelected != null)
            {
                InputField activeInputField = currentSelected.GetComponent<InputField>();
                if (activeInputField != null)
                {
                    // Check if the active input field belongs to the last line
                    Line lastLine = _lines[_lines.Count - 1];
                    if (activeInputField.transform.parent == lastLine.transform)
                    {
                        AddLine();
                    }
                    else
                    {
                        // Move to the next input field
                        Selectable next = activeInputField.FindSelectableOnDown();
                        if (next != null)
                        {
                            InputField nextInputField = next.GetComponent<InputField>();
                            if (nextInputField != null)
                            {
                                nextInputField.Select();
                            }
                        }
                    }
                }
            }
        }
    }

    public void DeleteState()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
            if (currentSelected != null)
            {
                InputField activeInputField = currentSelected.GetComponent<InputField>();
                if (activeInputField != null && activeInputField.caretPosition == 0 && string.IsNullOrEmpty(activeInputField.text))
                {
                    // Move to the previous input field
                    Selectable previous = activeInputField.FindSelectableOnUp();
                    if (previous != null)
                    {
                        InputField previousInputField = previous.GetComponent<InputField>();
                        if (previousInputField != null)
                        {
                            previousInputField.Select();
                        }
                    }
                }
            }
        }
    }

    public void AddLine()
    {
        var line = Instantiate(_linePrefab);
        line.transform.SetParent(_linesGroup);
        line.transform.localScale = new Vector3(_linePrefab.transform.localScale.x, _linePrefab.transform.localScale.y, _linePrefab.transform.localScale.z);

        // Add line number in the first.
        line.lineNumber = _lines.Count + 1;

        _lines.Add(line);

        // Set focus to the new line's input field
        InputField newInputField = line.GetComponentInChildren<InputField>();
        if (newInputField != null)
        {
            StartCoroutine(SelectInputField(newInputField));
        }
    }

    public void RemoveLine(int index)
    {
        var line = _lines[index];
        _lines.Remove(line);
        Destroy(line.gameObject);
    }

    public void AddLine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddLine();
        }
    }

    private IEnumerator SelectInputField(InputField inputField)
    {
        yield return new WaitForEndOfFrame();
        inputField.Select();
    }
}
