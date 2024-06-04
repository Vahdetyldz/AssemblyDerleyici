using UnityEngine;
using System;

public class BasicComputerCommands
{
    public int DR = 0; //Data register
    public int AC = 0; //Accumulator
    public int AR = 0; //Address register
    public int MAR = 0; //Content of address register
    public int SC = 0; // 
    public int IR = 0; // Instruction register
    public int E = 0; //
    public int PC = 0; //Program counter
    public void AND(int number)
    {
        MAR = number;
        DR = MAR;
        AC &= DR;
        SC = 0;
    }
    public void ADD(int number)
    {
        DR = number;
        AC += DR;
        SC = 0;
        DR = 0;
    }
    public void LDA(int number)
    {
        MAR = number;
        AC = number;
        SC = 0;
    }
    public void STA()
    {
        MAR = AC;
        SC = 0;
    }
    public void BUN(int number)
    {
        AR = number;
        PC = AR;
        SC = 0;
    }
    public int ISZ()
    {
        DR++;
        if (DR == 0)
        {
            PC++;
        }
        return DR;
    }
    public void CLA(){
        AC = 0;
    }
    public void CLE(){
        E = 0;
    }
    public void CMA(){
        AC = ~AC;
    }
    public void CME(){
        E = ~E;
    }
    public void CIR(){
        int tasanBit = AC & 1;
        AC >>= 1;
        int E_bit = (E & 1) << 15;
        AC |= E_bit;
        E = (E & ~1) | tasanBit;
    }
    public void CIL(){
        int tasanBit = (AC >> 15) & 1;
        AC = (AC << 1) & 0xFFFF;
        int E_bit = (E & 1);
        AC |= E_bit;
        E = (E & ~1) | tasanBit;
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
    public void print()
    {
        string binAC = Convert.ToString(AC, 2);
        string binE = Convert.ToString(E, 2);
        string binPC = Convert.ToString(PC, 2);
        Debug.Log("AC : " + binAC);
        Debug.Log("E : " + binE);
        Debug.Log("PC : " + binPC);
        Debug.Log("------------------------");
        Debug.Log("AC : " + AC);
        Debug.Log("E : " + E);
        Debug.Log("PC : " + PC);
    }
}
