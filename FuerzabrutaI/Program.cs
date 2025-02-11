using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del archivo que contiene la lista de contraseñas.
        String filePath = "C:\\Users\\nicol\\RiderProjects\\basura\\FuerzabrutaI\\FuerzabrutaI\\contra.txt";

        // Lee todas las líneas del archivo y las almacena en un array de strings.
        string[] passwords = File.ReadAllLines(filePath);

        // Crea un objeto Random para generar un índice aleatorio.
        Random random = new Random();
        int number = random.Next(0, passwords.Length); // Número aleatorio entre 0 y el tamaño del array.

        // Selecciona una contraseña aleatoria del archivo.
        String passwordChosenToBeCracked = passwords[number];

        // Genera el hash MD5 de la contraseña seleccionada.
        String hash = HashTheString(passwordChosenToBeCracked);

        // Muestra en consola la contraseña seleccionada y su hash.
        Console.WriteLine($"PALABRA A DESCIFRAR --> {passwordChosenToBeCracked}, HASH --> {hash}");
        
        // Crea un nuevo hilo para ejecutar la función de fuerza bruta en paralelo.
        Stopwatch stopwatch = Stopwatch.StartNew();
        Thread hilo = new Thread(() => CheckPasswords(passwords.Take(1075610).ToArray(), hash,stopwatch));
        Thread hilo2 = new Thread(() => CheckPasswords(passwords.Skip(1075610).Take(1075610).ToArray(), hash,stopwatch));
        hilo.Start(); // Inicia el hilo.
        hilo2.Start();
    }

    /// <summary>
    /// Calcula el hash MD5 de una cadena de texto.
    /// </summary>
    /// <param name="toString">La cadena de texto que se va a hashear.</param>
    /// <returns>El hash MD5 de la cadena en formato hexadecimal.</returns>
    static String HashTheString(String toString)
    {
        // Convierte la cadena de texto en un arreglo de bytes usando codificación ASCII.
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(toString);

        // Aplica el algoritmo MD5 al arreglo de bytes y lo convierte a una cadena hexadecimal.
        return ArrayToString(new MD5CryptoServiceProvider().ComputeHash(tmpSource));
    }

    /// <summary>
    /// Convierte un arreglo de bytes en una cadena hexadecimal.
    /// </summary>
    /// <param name="input">El arreglo de bytes a convertir.</param>
    /// <returns>Una cadena de texto en formato hexadecimal.</returns>
    static string ArrayToString(byte[] input)
    {
        // Crea un objeto StringBuilder para construir la cadena hexadecimal.
        StringBuilder sOutput = new StringBuilder(input.Length);

        // Itera sobre cada byte en el arreglo y lo convierte a formato hexadecimal (X2).
        for (int i = 0; i < input.Length; i++)
        {
            sOutput.Append(input[i].ToString("X2"));
        }

        // Devuelve la cadena completa en formato hexadecimal.
        return sOutput.ToString();
    }

    /// <summary>
    /// Realiza un ataque de fuerza bruta comparando hashes MD5 para encontrar una contraseña.
    /// </summary>
    /// <param name="passwords">Array de posibles contraseñas.</param>
    /// <param name="correctHash">El hash MD5 de la contraseña que se busca.</param>
    static void CheckPasswords(String[] passwords, String correctHash,Stopwatch stopwatch)
    {
        // Itera sobre cada contraseña en el array.
        
        foreach (var pass in passwords)
        {
            if (!stopwatch.IsRunning)
            {
                Console.WriteLine($"otro hilo encontro el password: parandose");
                break;
            }
            // Compara el hash MD5 de la contraseña actual con el hash correcto.
            if (HashTheString(pass) == correctHash)
            {
                stopwatch.Stop();
                // Si coinciden, imprime el mensaje de éxito y la contraseña encontrada.
                Console.WriteLine("Passwords Match");
                Console.WriteLine("---------------");
                Console.WriteLine($"{pass} --> {HashTheString(pass)} ---- time: {stopwatch} ");
                break; // Detiene el bucle ya que la contraseña fue encontrada.
            }
            else
            {
                // Si no coinciden, imprime un mensaje indicando que no hubo coincidencia.
                Console.WriteLine("Passwords Not Match");
            }
        }
    }
}
