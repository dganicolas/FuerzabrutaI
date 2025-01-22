using System;
using System.Security.Cryptography;
using System.Text;
// See https://aka.ms/new-console-template for more information
class Program{

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the FuerzabrutaI");
        String filePath = "contra.txt";
        string[] lines = File.ReadAllLines(filePath);
        Random rnd = new Random();
        int numeroRandom = rnd.Next(0,lines.Length);
        String escogido = lines[numeroRandom];
        String hash = hashearString(escogido);
        Console.WriteLine($"contraseña elegida {escogido} y su hash es {hash}");
        
        Thread hilo = new Thread();
    }

    public String hashearString(String escogido)
    {
        byte[] tmp = ASCIIEncoding.ASCII.GetBytes(escogido);
        return ArrayAString(new MD5CryptoServiceProvider().ComputeHash(tmp));
    }
    
    public string 
    public static void leerArchivo()
    {
        
    }
    
    public static 
}
