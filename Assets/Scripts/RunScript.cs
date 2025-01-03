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

    public CompilerConsole compilerConsole;

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
        bool Error = false;
        string data="";

        for (int i = 0; i < _lineManager._lines.Count; i++)//text rengi ilk haline �evirme (Metin giri�i)
        {
            _lineManager._lines[i].SetTextColor("black");
        }
        compilerConsole.SetInputFieldColor("black");//text rengi ilk haline �evirme (Consol)

        for (int i = 0; i < liste.Count; i++)//Hata s�n�f� olu�turup hatalar� orada kontrol et
        {
            string item = liste[i];
            for (int j = 0; j < item.Length; j++)
            {
                char c = item[j];
                if (Array.IndexOf(karakterDizisi, c) == -1)
                {
                    data += "Hata: "+"\n" + "r:" + (i + 1) + " c: " + (j + 1) + "\nge�ersiz karakter bulundu: " + c + "\n";
                    Error = true;
                }
            }
        }
        if (!Error)
        {
            for (int i = 0; i < liste.Count; i++)
            {
                tokens = liste[i].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries); // Sat�r� bo�luklardan ve virg�llerden ay�rarak komut ve arg�manlar� al
                if (tokens.Length > 0) komut[i] = tokens[0];
                if (tokens.Length > 1) arguman[i] = tokens[1];
                if (tokens.Length > 2) arguman2[i] = tokens[2];
                if (!IsThreeCharacters(komut[i]))
                {
                    data += "r: "+(i+1)+" "+komut[i] + "\n";
                    _lineManager._lines[i].SetTextColor("red");
                   Error = true;
                }
            }
            
            if (Error)
            {
                data = "Hata : \n" + data;
                compilerConsole.SetInputFieldColor("red");
                compilerConsole.SetInputFieldData(data);
                return;
            }
            for (_bCC.PC = 0; _bCC.PC < liste.Count; _bCC.PC++)
            {
                switch (komut[_bCC.PC])//ko�ul
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
                                Console.WriteLine("404"); //Hata yaz�cak burada
                                break;
                        }
                        break;

                }
                if (shouldStop) //Bayrak true ise d�ng�den ��k
                {
                    break;
                }
            }

            _bCC.PC++;
            string binAC = Convert.ToString(_bCC.AC, 2);
            string binE = Convert.ToString(_bCC.E, 2);
            string binPC = Convert.ToString(_bCC.PC, 2);

            data = "OUTPUT : \n" + "AC : " + binAC + "\n" + "E : " + binE + "\n" + "PC : " + binPC + "\n" + "---------------" + "\n" + "AC : " + _bCC.AC + "\n" + "E : " + _bCC.E + "\n" + "PC : " + _bCC.PC + "\n";
            data += "---------------" + "\n";

            for (int i = 0; i < liste.Count; i++)
            {
                if (arguman[i] == "HEX" | arguman[i] == "DEC")
                {
                    //Debug.Log(komut[i] + ": " + arguman2[i]);
                    data += komut[i] + ": " + arguman2[i] + "\n";
                }
            }
            compilerConsole.SetInputFieldData(data);
        }
        else if(Error)
        {
            compilerConsole.SetInputFieldData(data);
        }
        
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
    bool IsThreeCharacters(string input)
    {
        // String'in uzunlu�unu kontrol eder
        if (input.Length <= 3)
        {
            return true; // E�er 3 karakter ise true d�ner
        }
        else
        {
            return false; // 3 karakter de�ilse false d�ner
        }
    }

    private void GetLineData()
    {
        liste.Clear();
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
