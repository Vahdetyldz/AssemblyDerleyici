using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    private Line _linePrefab;
    [SerializeField]
    private int _initialLineCount;

    private List<Line> _lines = new List<Line>();

    private void Start()
    {
        //Add initial lines.
        for (int i = 0; i < _initialLineCount; i++)
        {
            var line = Instantiate(_linePrefab);
            line.transform.parent = this.transform;

            _lines.Add(line);
        }
    }

    public void AddLine()
    {
        var line = Instantiate(_linePrefab);
        line.transform.parent = this.transform;

        _lines.Add(line);
    }

    public void AddLine(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var line = Instantiate(_linePrefab);
            line.transform.parent = this.transform;

            _lines.Add(line);
        }
    }
}
