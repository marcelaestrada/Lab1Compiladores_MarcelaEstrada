using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Compis_MarcelaEstrada
{
    public class Scanner
    {
        private const char EOF = (char)0;
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;
        int banderaLParen = 0;
        int banderaRParen = 0;

        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }

        public Token GetToken()
        {
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;
            while (!tokenFound)
            {
                if(!(_regexp.Length == _index))
                {
                    char peek = _regexp[_index];
                    switch (_state)
                    {
                        case 0:
                            switch (peek)
                            {
                                case (char)TokenType.Substract:
                                    tokenFound = true;
                                    result.Tag = (TokenType)peek;
                                    result.Value = peek;
                                    _state = 1;
                                    break;

                                case (char)TokenType.LParen:
                                    tokenFound = true;
                                    result.Tag = (TokenType)peek;
                                    result.Value = peek;
                                    _state = 2;
                                    banderaLParen++;
                                    break;

                                default:
                                    tokenFound = true;
                                    result.Tag = TokenType.Symbol;
                                    result.Value = peek;
                                    _state = 3;
                                    break;
                            }
                            break;

                        case 1:
                            switch (peek)
                            {
                                case (char)TokenType.LParen:
                                    tokenFound = true;
                                    result.Tag = (TokenType)peek;
                                    result.Value = peek;
                                    _state = 2;
                                    banderaLParen++;
                                    break;

                                default:
                                    tokenFound = true;
                                    result.Tag = TokenType.Symbol;
                                    result.Value = peek;
                                    _state = 4;
                                    break;
                            }
                            break;

                        case 2:
                            if (peek == '0' | peek == '1' | peek == '2' | peek == '3' | peek == '4' | peek == '5' | peek == '6' | peek == '7' | peek == '8' | peek == '9')
                            {
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                _state = 4;
                            }
                            else
                            {
                                switch (peek)
                                {
                                    case (char)TokenType.Substract:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 1;
                                        break;
                                }
                            }
                            break;

                        case 3:
                            if (peek == '0' | peek == '1' | peek == '2' | peek == '3' | peek == '4' | peek == '5' | peek == '6' | peek == '7' | peek == '8' | peek == '9')
                            {
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                _state = 3;
                            }
                            else
                            {
                                switch (peek)
                                {
                                    case (char)TokenType.LParen:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 2;
                                        banderaLParen++;
                                        break;

                                    case (char)TokenType.Add:
                                    case (char)TokenType.Multiply:
                                    case (char)TokenType.Divide:
                                    case (char)TokenType.Substract:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 5;
                                        break;

                                    case (char)TokenType.EOF:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.banderaLParen = banderaLParen;
                                        result.banderaRParen = banderaRParen;
                                        _state = 3;
                                        break;

                                    case (char)TokenType.RParen:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 3;
                                        banderaRParen++;
                                        break;
                                }
                            }
                            break;

                        case 4:
                            if (peek == '0' | peek == '1' | peek == '2' | peek == '3' | peek == '4' | peek == '5' | peek == '6' | peek == '7' | peek == '8' | peek == '9')
                            {
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                _state = 4;
                            }
                            else
                            {
                                switch (peek)
                                {
                                    case (char)TokenType.Add:
                                    case (char)TokenType.Multiply:
                                    case (char)TokenType.Divide:
                                    case (char)TokenType.Substract:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 5;
                                        break;
                                }
                            }
                            break;

                        case 5:
                            if (peek == '0' | peek == '1' | peek == '2' | peek == '3' | peek == '4' | peek == '5' | peek == '6' | peek == '7' | peek == '8' | peek == '9')
                            {
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek;
                                _state = 3;
                            }
                            else
                            {
                                switch (peek)
                                {
                                    case (char)TokenType.RParen:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 3;
                                        banderaRParen++;
                                        break;

                                    case (char)TokenType.LParen:
                                        tokenFound = true;
                                        result.Tag = (TokenType)peek;
                                        result.Value = peek;
                                        _state = 2;
                                        banderaLParen++;
                                        break;
                                }
                            }

                            break;

                        default:
                            throw new Exception("Lex error");
                    }
                    _index++;
                }
                else
                {
                    throw new Exception("Lex error");
                }
                
            }
            return result;
        }
    }
}
