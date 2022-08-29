//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;
using ClassLibrary;

namespace ConsoleApplication
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            Test_1(100);
            GC.Collect();                   // Necesito llamar a GC.
            GC.WaitForPendingFinalizers();  // De lo contrario no se ejecuta el destructor.
            Console.WriteLine(Train.Count);
            // Se construyen y destruyen la totalidad de las instancias creadas.

            Test_1(10000000);
            GC.Collect();                   // Necesito llamar a GC.
            GC.WaitForPendingFinalizers();  // De lo contrario no se ejecuta el destructor.
            Console.WriteLine(Train.Count);
            // Se construyen y destruyen la totalidad de las instancias creadas.

            Test_2();
        }

        public static void Test_1(int instancias)
        {
            Train[] tren = new Train[instancias]; 
            
            for (int i = 0; i < instancias; i++)
            {
                tren[i] = new Train($"{i}");
            }
            Console.WriteLine(Train.Count);
        }
        
        public static void Test_2()
        {
            var t1 = new Train("Last Train To London");
            var t2 = new Train("Last Train To London");
            var t3 = new Train("Runaway Train");

            Console.WriteLine(t1==t2);
            // Si bien ambas instancias contienen la misma información,
            // estas poseen un identificador diferente, el cual es único para cada instancia.

            Console.WriteLine(t2==t3);
            // Misma lógica que en el caso anterior, sumando el hecho de que a su vez
            // tienen información distinta.
        }
    }
}