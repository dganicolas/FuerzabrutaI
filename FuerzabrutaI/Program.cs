using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;
using FuerzabrutaI;

class Program
{
    static void Main(string[] args)
    {
        //arreglar
        String filePath = "contra.txt";
        Programa programa = new Programa(filePath);
        TimeSpan x = programa.programa(2);
        TimeSpan y = programa.programa(2);
        if (x < y)
        {
            Console.WriteLine($"ha ganado el valor x: valor mayor{y} valor menor {x}");
        }
        else
        {
            Console.WriteLine($"ha ganado el valor y: valor mayor{x} valor menor {y}");
        }
    }
}
