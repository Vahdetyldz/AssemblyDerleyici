using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
public class RunScript : MonoBehaviour
{
    public Button runButton;
    [SerializeField]
    private LineManager _lineManager;
    private BasicComputerCommands _bCC;
    public List<string> liste= new List<string>();
    string[] tokens;
    string[] komut;
    string[] arguman;
    string[] arguman2;
    private void Start()
    {
        runButton.onClick.AddListener(Main);
    }
    private void Main()
    {
        _bCC = new BasicComputerCommands();
        GetLineData();
        char[] karakterDizisi = "ABCDEFGHIJKLMNOPQRSTUVWXYZ,0123456789 ".ToCharArray();
        bool shouldStop = false;
        komut = new string[liste.Count];
        arguman = new string[liste.Count];
        arguman2 = new string[liste.Count];

        for (int i = 0; i < liste.Count; i++)//Hata sýnýfý oluþturup hatalarý orada kontrol et
        {
            string item = liste[i];
            for (int j = 0; j < item.Length; j++)
            {
                char c = item[j];
                if (Array.IndexOf(karakterDizisi, c) == -1)
                {
                    Debug.Log("Hata: " + "r:" + (i + 1) + " c: " + (j + 1) + "\ngeçersiz karakter bulundu: " + c);
                }
            }
        }
        for (int i = 0; i < liste.Count; i++)
        {
            tokens = liste[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries); // Satýrý boþluklardan ve virgüllerden ayýrarak komut ve argümanlarý al
            if (tokens.Length > 0) komut[i] = tokens[0];
            if (tokens.Length > 1) arguman[i] = tokens[1];
            if (tokens.Length > 2) arguman2[i] = tokens[2];
        }

        for (_bCC.PC = 0; _bCC.PC < liste.Count; _bCC.PC++)
        {
            switch (komut[_bCC.PC])//koþul
            {
                case "AND":
                    _bCC.AND(FindVariable(arguman[_bCC.PC]));
                    break;
                case "ADD":
                    _bCC.ADD(FindVariable(arguman[_bCC.PC]));
                    break;
                case "LDA":
                    if (arguman[_bCC.PC] == "VA1")
                    {
                        Console.WriteLine("LDA AC =" + arguman[_bCC.PC]);
                    }
                    _bCC.LDA(FindVariable(arguman[_bCC.PC]));
                    if (arguman[_bCC.PC] == "VA1")
                    {
                        Console.WriteLine("LDA AC =" + _bCC.AC);
                    }
                    break;
                case "STA":
                    if (arguman[ChangeVariable(arguman[_bCC.PC])] == "HEX")
                    {
                        arguman2[ChangeVariable(arguman[_bCC.PC])] = _bCC.AC.ToString("X");
                    }
                    else if (arguman[ChangeVariable(arguman[_bCC.PC])] == "DEC")
                    {
                        arguman2[ChangeVariable(arguman[_bCC.PC])] = _bCC.AC.ToString();
                    }
                    break;
                case "BUN":
                    if (arguman2[_bCC.PC] == "I")
                    {
                        _bCC.PC = int.Parse(arguman2[FindFonk(arguman[_bCC.PC])]);
                    }
                    else
                    {
                        _bCC.BUN(FindVariable(arguman[_bCC.PC]) - 1);
                    }
                    break;
                case "BSA":
                    arguman2[FindFonk(arguman[_bCC.PC])] = (_bCC.PC).ToString();
                    _bCC.PC = FindFonk(arguman[_bCC.PC]);
                    break;
                case "ISZ":

                    if (arguman[ChangeVariable(arguman[_bCC.PC])] == "HEX")
                    {
                        _bCC.DR = int.Parse(arguman2[ChangeVariable(arguman[_bCC.PC])], NumberStyles.HexNumber);
                        arguman2[ChangeVariable(arguman[_bCC.PC])] = _bCC.ISZ().ToString("X");
                    }
                    else if (arguman[ChangeVariable(arguman[_bCC.PC])] == "DEC")
                    {
                        _bCC.DR = int.Parse(arguman2[ChangeVariable(arguman[_bCC.PC])]);
                        arguman2[ChangeVariable(arguman[_bCC.PC])] = _bCC.ISZ().ToString();
                    }
                    break;
                case "CLA":
                    _bCC.CLA();
                    break;
                case "CLE":
                    _bCC.CLE();
                    break;
                case "CMA":
                    _bCC.CMA();
                    break;
                case "CME":
                    _bCC.CME();
                    break;
                case "CIR":
                    _bCC.CIR();
                    break;
                case "CIL":
                    _bCC.CIL();
                    break;
                case "INC":
                    _bCC.INC();
                    break;
                case "SPA":
                    _bCC.SPA();
                    break;
                case "SNA":
                    _bCC.SNA();
                    break;
                case "SZA":
                    _bCC.SZA();
                    break;
                case "SZE":
                    _bCC.SZE();
                    break;
                case "HLT":
                    shouldStop = true;
                    break;
                default:
                    switch (arguman[_bCC.PC])
                    {
                        case "AND":
                            _bCC.AND(FindVariable(arguman[_bCC.PC]));
                            break;
                        case "ADD":
                            _bCC.ADD(FindVariable(arguman2[_bCC.PC]));
                            break;
                        case "LDA":
                            _bCC.LDA(FindVariable(arguman[_bCC.PC]));
                            break;
                        case "STA":
                            break;
                        case "BUN":
                            _bCC.BUN(FindVariable(arguman[_bCC.PC]));
                            break;
                        case "BSA":
                            break;
                        case "ISZ":
                            break;
                        case "CLA":
                            _bCC.CLA();
                            break;
                        case "CLE":
                            _bCC.CLE();
                            break;
                        case "CMA":
                            _bCC.CMA();
                            break;
                        case "CME":
                            _bCC.CME();
                            break;
                        case "CIR":
                            _bCC.CIR();
                            break;
                        case "CIL":
                            _bCC.CIL();
                            break;
                        case "INC":
                            _bCC.INC();
                            break;
                        case "SPA":
                            _bCC.SPA();
                            break;
                        case "SNA":
                            _bCC.SNA();
                            break;
                        case "SZA":
                            _bCC.SZA();
                            break;
                        case "SZE":
                            _bCC.SZE();
                            break;
                        case "HLT":
                            shouldStop = true;
                            break;
                        default:
                            Console.WriteLine("404"); //Hata yazýcak burada
                            break;
                    }
                    break;

            }
            if (shouldStop) //Bayrak true ise döngüden çýk
            {
                break;
            }
        }

        _bCC.PC++;
        _bCC.print();
        Debug.Log("-------------------------");
    }
    int FindVariable(string arg)
    {
        int number = 0;
        for (int i = 0; i < komut.Length; i++)
        {
            if (komut[i] == arg)
            {
                switch (arguman[i])
                {
                    case "DEC":
                        number = int.Parse(arguman2[i]);
                        break;
                    case "HEX":
                        try
                        {
                            number = int.Parse(arguman2[i], NumberStyles.HexNumber);
                        }
                        catch (Exception)
                        {
                            number = int.Parse(arguman2[i]);
                        }
                        break;
                    default:
                        number = i;
                        break;
                }
            }
        }
        return number;
    }
    int FindFonk(string arg)
    {
        int number = 0;
        for (int i = 0; i < komut.Length; i++)
        {
            if (komut[i] == arg)
            {
                number = i;
            }
        }
        return number;
    }
    int ChangeVariable(string arg)
    {
        int number = 0;
        for (int i = 0; i < komut.Length; i++)
        {
            if (komut[i] == arg)
            {
                number = i;
                break;
            }
        }
        return number;
    }
    /*public void Clear()
    {
        
    }*/
    private void GetLineData()
    {
        for (int i = 0; i < _lineManager._lines.Count; i++)
        {
            liste.Add(_lineManager._lines[i].GetData()) ;
            
        }
        /*for (int i = 0; _lineManager._lines[i].GetData()!=null; i++)
        {
            liste[i] = _lineManager._lines[i].GetData();
        }*/
    }
}
