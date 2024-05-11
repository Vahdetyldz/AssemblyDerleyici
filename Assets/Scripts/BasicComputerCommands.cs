using UnityEngine;
using System;

public class BasicComputerCommands : MonoBehaviour
{
    int DR = 0; //Data register
    int AC = 0; //Accumulator
    int AR = 0; //Address register
    int MAR = 0; //Content of address register
    int SC = 0; // 
    int IR = 0; // Instruction register
    int E = 0; //
    int PC = 0; //Program counter
    //int S = 0;
    string binaryNumber;

    public void IntToBin(long intNum)// 10'luk sayý sisteminden 2'lik sayý sistemine dönüþtürme
    {
        int[] kalan = new int[64]; // En fazla 64 bit
        int index = 0;

        while (intNum > 0)
        {
            kalan[index] = (int)(intNum % 2); // 2'lik deðeri hesapla
            intNum = intNum / 2;
            index++;
        }

        // BinaryNumber hesaplama
        for (int i = index - 1; i >= 0; i--)
        {
            binaryNumber += kalan[i].ToString();
        }
    }
    public long BinToInt()// 2'lik sayý sisteminden 10'luk sayý sistemine dönüþtürme
    {
        long intNum = 0;
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (binaryNumber[i] == '1')
            {
                intNum += (long)(Math.Pow(2, binaryNumber.Length - i - 1));
            }
        }
        return intNum;
    }
    public void Complement()
    {
        char[] yeniBinaryNumber = new char[binaryNumber.Length]; // Yeni bir char dizisi oluþturuyoruz
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            if (binaryNumber[i] == '0')
            {
                yeniBinaryNumber[i] = '1'; // 0 ise 1'e çeviriyoruz
            }
            else
            {
                yeniBinaryNumber[i] = '0'; // 1 ise 0'a çeviriyoruz
            }
        }
        string yeniBinaryString = new string(yeniBinaryNumber); // Char dizisini stringe dönüþtürüyoruz
        binaryNumber = yeniBinaryString;
    }
    public void AND()
    {
        DR = MAR; //DR <-- AR
        AC = AC & DR;
        SC = 0;
        PC++;
    }
    public void ADD()
    {
        DR = MAR;
        AC = AC + DR;
        //E=Cout; Bit bazýnda toplama iþlemi yap
        SC = 0;
    }
    public void LDA()
    {
        DR = MAR;
        AC = DR;
        SC = 0;
    }
    public void STA()
    {
        MAR = AC;
        SC = 0;
    }
    public void BUN()
    {
        PC = AR;
        SC = 0;
    }
    public void BSA()
    {
        MAR = PC;
        AR++;
        PC = AR;
        SC = 0;
    }
    public void ISZ()
    {
        DR = MAR;
        DR++;
        MAR = DR;
        if (DR == 0)
        {
            PC++;
        }
    }
    public void CLA(){
        AC = 0;
    }
    public void CLE(){
        E = 0;
    }
    public void CMA(){
        IntToBin(AC);
        Complement();
        BinToInt();
    }
    public void CME(){
        IntToBin(E);
        Complement();
        BinToInt();
    }
    public void CIR(){
        IntToBin(AC);
        char[] newBinaryNumber = new char[binaryNumber.Length];
        char[] tempArray = new char[binaryNumber.Length];
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            newBinaryNumber[i] = binaryNumber[i];
        }
        int tempE = E;
        E = newBinaryNumber[binaryNumber.Length - 1] - 48;
        for (int i = 1; i < newBinaryNumber.Length; i++)
        {
            tempArray[i] = newBinaryNumber[i - 1];
        }
        tempArray[0] = (char)(tempE + '0');
        string yeniBinaryString = new string(tempArray); // Char dizisini stringe dönüþtürüyoruz
        binaryNumber = yeniBinaryString;
        BinToInt();
    }
    public void CIL(){
        IntToBin(AC);
        char[] newBinaryNumber = new char[binaryNumber.Length];
        char[] tempArray = new char[binaryNumber.Length];
        for (int i = 0; i < binaryNumber.Length; i++)
        {
            newBinaryNumber[i] = binaryNumber[i];
        }
        int tempE = E;
        E = newBinaryNumber[0] - 48;
        for (int i = 0; i < newBinaryNumber.Length - 1; i++)
        {
            tempArray[i] = newBinaryNumber[i + 1];
        }
        tempArray[newBinaryNumber.Length - 1] = (char)(tempE + '0');
        string yeniBinaryString = new string(tempArray); // Char dizisini stringe dönüþtürüyoruz
        binaryNumber = yeniBinaryString;
    }
    public void INC(){
        AC++;
    }
    public void SPA(){
        if (AC>0)
        {
            PC++;
        }
    }
    public void SNA(){
        if (AC<0)
        {
            PC++;
        }
    }
    public void SZA(){
        if (AC == 0)
        {
            PC++;
        }
    }
    public void SZE(){
        if (E==0)
        {
            PC++;
        }
    }
    /*public void HLT(){
        S = 0;
    }*/
    public void print()
    {
        string binDR = Convert.ToString(DR, 2);
        string binAC = Convert.ToString(AC, 2);
        string binAR = Convert.ToString(AR, 2);
        string binMAR = Convert.ToString(MAR, 2);
        string binSC = Convert.ToString(SC, 2);
        string binIR = Convert.ToString(IR, 2);
        string binE = Convert.ToString(E, 2);
        string binPC = Convert.ToString(PC, 2);
        Debug.Log("DR : " + binDR);
        Debug.Log("AC : " + binAC);
        Debug.Log("AR : " + binAR);
        Debug.Log("MAR : " + binMAR);
        Debug.Log("SC : " + binSC);
        Debug.Log("IR : " + binIR);
        Debug.Log("E : " + binE);
        Debug.Log("PC : " +binPC);
    }
}
