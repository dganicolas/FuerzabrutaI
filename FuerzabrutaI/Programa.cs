using System.Diagnostics;

namespace FuerzabrutaI;

class Programa(String filePath){

    private String[] leerArchivo()
    {
        return File.ReadAllLines(filePath);
    }

    private int numeroRandom()
    {
        Random random = new Random();
        return random.Next(0, passwords.Length);
    }
    public TimeSpan programa(int numeroHilo)
    {
        ArrayToString ats = new ArrayToString();
        HashTheString hs = new HashTheString(ats);
        CheckPasswords cp = new CheckPasswords(hs);
        // Ruta del archivo que contiene la lista de contraseñas.
        

        // Lee todas las líneas del archivo y las almacena en un array de strings.
        string[] passwords = leerArchivo();
        
        
        // Crea un objeto Random para generar un índice aleatorio.
        

        // Selecciona una contraseña aleatoria del archivo.
        String passwordChosenToBeCracked = passwords[numeroRandom()];

        // Genera el hash MD5 de la contraseña seleccionada.
        String hash = hs.hashTheString(passwordChosenToBeCracked);
        
        Console.WriteLine($"PALABRA A DESCIFRAR --> {passwordChosenToBeCracked}, HASH --> {hash}");
        
        Thread[] hilosParaTodos = new Thread[numeroHilo];
        // Tamaño de cada sublista
        int segmentSize = passwords.Length / numeroHilo;
        Stopwatch stopwatch = Stopwatch.StartNew();
        // Inicializar y arrancar los hilos
        Console.WriteLine($"{passwords.Length}");
        for (int i = 0; i < hilosParaTodos.Length; i++)
        {
            int numero = i;
            int start = i * segmentSize;
            int end = (start + segmentSize >= passwords.Length - 1) ? passwords.Length : start + segmentSize;
            Console.WriteLine($"{i}principio {start} fin {end}");
            hilosParaTodos[i] = new Thread(() =>
            {
                cp.checkPasswords($"{numero}",passwords.Skip(start).Take(end).ToArray(), hash,stopwatch);
            });
        }
        for (int i = 0; i < hilosParaTodos.Length; i++)
        {
            hilosParaTodos[i].Start();
        }

        // Esperar a que todos los hilos terminen
        foreach (Thread hilo in hilosParaTodos)
        {
            hilo.Join();
        }

        Console.WriteLine("Procesamiento completado.");
        return stopwatch.Elapsed;
    }
}