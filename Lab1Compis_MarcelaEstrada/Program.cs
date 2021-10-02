using System;
using System.Collections.Generic;

namespace Lab1Compis_MarcelaEstrada
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programa = true;
            while (programa) //se repite mientras el usuario no desee salir del programa
            {
                Console.Clear();
                Console.WriteLine("LABORATORIO 1\nA continuación, ingrese la operación aritmética que desea resolver:");
                string regexp = Console.ReadLine();
                Parser parser = new Parser();
                int resultado = parser.Parse(regexp);
                Console.Clear();
                Console.WriteLine("LABORATORIO 1\nOperación sin errores");
                Console.WriteLine(regexp + " = " + resultado);
                Console.ReadLine();
                Console.WriteLine("\n¿Desea salir del programa? S/N");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper() == "S")
                {
                    programa = false;
                }
            }
        }
    }
}
