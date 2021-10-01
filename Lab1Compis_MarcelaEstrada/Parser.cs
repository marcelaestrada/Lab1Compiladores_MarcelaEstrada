using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1Compis_MarcelaEstrada
{
    class Parser
    {
        Scanner _scanner;
        Token _token;

        private void E()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                case TokenType.Substract:
                    T();
                    EP();
                    break;

                default:
                    break;
            }
        }

        private void EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Add:
                    Match(TokenType.Add);
                    T();
                    EP();
                    break;

                case TokenType.Substract:
                    Match(TokenType.Substract);
                    T();
                    EP();
                    break;

                default:
                    break;
            }
        }

        private void T()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                case TokenType.Substract:
                    F();
                    TP();
                    break;

                default:
                    break;
            }
        }

        private void TP()
        {
            switch (_token.Tag)
            {
                case TokenType.Multiply:
                    Match(TokenType.Multiply);
                    F();
                    TP();
                    break;

                case TokenType.Divide:
                    Match(TokenType.Divide);
                    F();
                    TP();
                    break;

                default:
                    break;
            }
        }

        private void F()
        {
            switch (_token.Tag)
            {
                case TokenType.Substract:
                    Match(TokenType.Substract);
                    F();
                    break;

                case TokenType.Symbol:
                    Match(TokenType.Symbol);
                    F();
                    break;

                case TokenType.LParen:
                    Match(TokenType.LParen);
                    E();
                    Match(TokenType.RParen);
                    break;

                default:
                    break;
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
                throw new Exception("Error de sintaxis");
            }
        }

        public void Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Symbol:
                    E();
                    break;

                default:
                    break;
            }
            Match(TokenType.EOF);
        }
    }
}
