using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Compis_MarcelaEstrada
{
    public enum TokenType
    {
        Multiply = '*',
        Divide = '/',
        Add = '+',
        Substract = '-',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Symbol = (char)1,
    }
}
