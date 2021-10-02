using System;
using System.Collections.Generic;

namespace Lab1Compis_MarcelaEstrada
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("LABORATORIO 1\nIngrese la expresion algebraica que se desea resolver");
            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            int resultado = parser.Parse(regexp);
            Console.Clear();
            Console.WriteLine("Expresión sin errores");
            Console.WriteLine(regexp + " = " + resultado);
            Console.ReadLine();

        }
    }
}
