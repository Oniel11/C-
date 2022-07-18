using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)

        {
            Comenzar comenzar = new Comenzar();
            comenzar.iniciar();
          
            Console.ReadKey();
        }
    }
}
