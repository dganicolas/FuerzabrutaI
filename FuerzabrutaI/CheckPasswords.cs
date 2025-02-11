using System.Diagnostics;

namespace FuerzabrutaI;

class CheckPasswords(HashTheString hs)
{
    public void checkPasswords(String hilo, String[] passwords, String correctHash,Stopwatch stopwatch)
    {
        // Itera sobre cada contraseña en el array.
        
        foreach (var pass in passwords)
        {
            if (!stopwatch.IsRunning)
            {
                Console.WriteLine("otro hilo encontro el password: parandose");
                break;
            }
            // Compara el hash MD5 de la contraseña actual con el hash correcto.
            if (hs.hashTheString(pass) == correctHash)
            {
                stopwatch.Stop();
                // Si coinciden, imprime el mensaje de éxito y la contraseña encontrada.
                Console.WriteLine("Passwords Match");
                Console.WriteLine("---------------");
                Console.WriteLine($"{pass} --> {hs.hashTheString(pass)} ---- time: {stopwatch} ");
                break;
            }
            Console.WriteLine($"Hilo: {hilo} Passwords Not Match");
        }
    }
}