using System;
using System.Collections.Generic;

namespace Lab1Compis_MarcelaEstrada
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("LABORATORIO 1\nIngrese la expresion algebraica que se desea resolver");
            //string regex = Console.ReadLine();
            //Scanner scanner = new Scanner(regex);
            //Token nextToken;

            ////do
            ////{
            ////    nextToken = scanner.GetToken();
            ////    Console.WriteLine("Token: {0}\nValor: {1} \n", nextToken.Tag, nextToken.Value);
            ////    if(nextToken.banderaRParen != nextToken.banderaLParen)
            ////    {
            ////        throw new Exception("Lex error");
            ////    }
            ////} while (nextToken.Tag != TokenType.EOF);
            ///

            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            parser.Parse(regexp);
            Console.WriteLine("Expresión OK");
            Console.ReadLine();

        }
    }
}
