using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    private Line _linePrefab;
    [SerializeField]
    private Transform _linesGroup;
    [SerializeField]
    private int _initialLineCount;

    public List<Line> _lines = new List<Line>();
    private void Start()
    {
        //Add initial lines to list.
        AddLine(_initialLineCount);
    }

    private void Update()
    {
        EnterState();
    }

    public void EnterState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AddLine();
        }
    }

    public void AddLine()
    {
        var line = Instantiate(_linePrefab);
        line.transform.SetParent(_linesGroup);
        line.transform.localScale =
            new Vector3(_linePrefab.transform.localScale.x, _linePrefab.transform.localScale.y, _linePrefab.transform.localScale.z);

        //Add line number in the first.
        line.lineNumber = _lines.Count + 1;

        _lines.Add(line);
    }

    public void AddLine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            AddLine();
        }
    }
}
