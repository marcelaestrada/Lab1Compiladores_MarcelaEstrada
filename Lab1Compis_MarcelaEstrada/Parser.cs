using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Compis_MarcelaEstrada
{
    class Parser
    {
        Scanner _scanner;
        Token _token;
        int resultado = 0;
        string numero = "";

        private int E()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                case TokenType.Substract:
                    int t = T();
                    int res = EP(t);
                    return res;


                default:
                    return resultado;
            }
        }

        private int EP(int num)
        {
            switch (_token.Tag)
            {
                case TokenType.Add:
                    Match(TokenType.Add);
                    resultado = num + T();
                    EP(resultado);
                    return resultado;

                case TokenType.Substract:
                    Match(TokenType.Substract);
                    resultado = num - T();
                    EP(resultado);
                    return resultado;

                default:
                    return num;
            }
        }

        public int inverso()
        {
            switch (_token.Tag)
            {
                case TokenType.Symbol:
                    int value = Convert.ToInt32(Convert.ToString(_token.Value));
                    numero += value;
                    Match(TokenType.Symbol);
                    inverso();
                    value = Convert.ToInt32(numero);
                    return -value;

                default:
                    return resultado;

            }
            
        }

        private int T()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                    int f = F();
                    numero = "";
                    int tp = TP(f);
                    if (tp != 0)
                    {
                        return tp;
                    }
                    else
                    {
                        return f;
                    }

                case TokenType.Substract:
                    Match(TokenType.Substract);
                    int inver = inverso();
                    numero = "";
                    int tp2 = TP(inver);
                    if (tp2 != 0)
                    {
                        return tp2;
                    }
                    else
                    {
                        return inver;
                    }

                default:
                    return resultado;
            }
        }

        private int TP(int num)
        {
            switch (_token.Tag)
            {
                case TokenType.Multiply:
                    Match(TokenType.Multiply);
                    int f = F();
                    numero = "";
                    resultado = f * num;
                    TP(resultado);
                    return resultado;

                case TokenType.Divide:
                    Match(TokenType.Divide);
                    int g = F();
                    numero = "";
                    resultado = num/g;
                    TP(resultado);
                    return resultado;

                default:
                    return 0;
            }
        }

        private int F()
        {
            switch (_token.Tag)
            {
                case TokenType.Symbol:
                    int value2 = Convert.ToInt32(Convert.ToString(_token.Value));
                    numero += value2;
                    Match(TokenType.Symbol);
                    F();
                    value2 = Convert.ToInt32(numero);
                    return value2;

                case TokenType.LParen:
                    Match(TokenType.LParen);
                    int e = E();
                    Match(TokenType.RParen);
                    return e; 

                default:
                    return resultado;
            }
        }

        private void Match(TokenType tag)
        {
            if(_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Syntax error");
            }
        }

        public int Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            int res = 0;
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                case TokenType.Substract:
                    res = E();
                    break;

                default:
                    break;
            }
            Match(TokenType.EOF);

            return res;
        }
    }
}
