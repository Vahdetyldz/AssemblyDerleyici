using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCode : MonoBehaviour
{
    [SerializeField]
    private LineManager _lineManager;
    List<string> SampleCode1 = new List<string>() {
                "LDA A",
                "ADD B",
                "STA CTR",
                "HLT",
                "A, DEC 15",
                "B, DEC 21",
                "CTR, HEX 0",
                "HLT",
    };
    List<string> SampleCode2 = new List<string>(){
                "LDA A",
                "SZA",
                "BUN GIT",
                "HLT",
                "GIT, CMA",
                "INC",
                "STA CTR",
                "CLA",
                "LOP, ADD B",
                "ISZ CTR",
                "BUN LOP",
                "HLT",
                "A, DEC 13",
                "B, DEC 7",
                "CTR, HEX 0"
    };
    List<string> SampleCode3 = new List<string>(){
                "CLE",
                "CLA",
                "STA CTR",
                "LDA WRD",
                "SZA",
                "BUN ROT",
                "BUN STP",
                "ROT, CIL",
                "SZE",
                "BUN AGN",
                "BUN ROT",
                "AGN, CLE",
                "ISZ CTR",
                "SZA",
                "BUN ROT",
                "STP, HLT",
                "CTR, HEX 0",
                "WRD, HEX 62C1",
                "END"
    };
    List<string> SampleCode4 = new List<string>() {
                "LDA X",
                "BSA XOR",
                "LDA Y",
                "BSA YOR",
                "LDA VA1",
                "CMA",
                "STA TMP",
                "LDA VA2",
                "CMA",
                "AND TMP",
                "CMA",
                "HLT",
                "XOR, HEX 0",
                "CMA",
                "STA TMP",
                "LDA Y",
                "AND TMP",
                "STA VA1",
                "BUN XOR I",
                "YOR, HEX 0",
                "CMA",
                "STA TMP",
                "LDA X",
                "AND TMP",
                "STA VA2",
                "BUN YOR I",
                "VA1, HEX 0",
                "VA2, HEX 0",
                "X, HEX 1234",
                "Y, HEX 1234",
                "TMP, HEX 0",
                "END",
    };
    public void Code(List<string> list)
    {
        //ClearConsole();
        Clear();

        while (list.Count - _lineManager._lines.Count > 0)
        {
            AddLine();
        }
        int lineCtr = _lineManager._lines.Count;
        for (int i = 0; _lineManager._lines.Count!= list.Count; i++)
        {
            RemoveLine(list.Count);
        }

        for (int i = 0; i < list.Count; i++)
        {
            _lineManager._lines[i].SetData(list[i]);
        }
    }
    public void Code1()
    {
        Code(SampleCode1);
    }
    public void Code2()
    {
        Code(SampleCode2);
    }
    public void Code3()
    {
        Code(SampleCode3);
    }
    public void Code4()
    {
        Code(SampleCode4);
    }
    /*private static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }*/

    private void AddLine()
    {
        _lineManager.AddLine();
    }
    private void RemoveLine(int index)
    {
        _lineManager.RemoveLine(index);
    }
    public void Clear()
    {
        for (int i = 0; i < _lineManager._lines.Count; i++)
        {
            _lineManager._lines[i].SetData(null);
        }
    }
}
