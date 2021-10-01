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
                    return T() + EP();

                case TokenType.Substract:
                    return -EP()+T();

                default:
                    return resultado;
            }
        }

        private int EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Add:
                    Match(TokenType.Add);
                    return T() + EP();

                case TokenType.Substract:
                    Match(TokenType.Substract);
                    return T() - EP();

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
                    int tp = TP();
                    return f + tp;

                case TokenType.Substract:
                    Match(TokenType.Substract);
                    return F() - TP();
                    //return -F() + TP();

                default:
                    return resultado;
            }
        }

        private int TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Multiply:
                    Match(TokenType.Multiply);
                    return F() * TP();

                case TokenType.Divide:
                    Match(TokenType.Divide);
                    return F() / TP();

                default:
                    return 0;
            }
        }

        private int F()
        {
            switch (_token.Tag)
            {
                //case TokenType.Substract:
                //    Match(TokenType.Substract);
                //    int value = Convert.ToInt32(Convert.ToString(_token.Value));
                //    return F();

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
            numero = "";
        }

        private void Match(TokenType tag)
        {
            if(_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de sintaxis");
            }
        }

        public int Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                case TokenType.Substract:
                    resultado = E();
                    break;

                default:
                    break;
            }
            Match(TokenType.EOF);

            return resultado;
        }
    }
}
