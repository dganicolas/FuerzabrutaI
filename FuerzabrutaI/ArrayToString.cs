using System.Text;

namespace FuerzabrutaI;

class ArrayToString
{
    public string arrayToString(byte[] input)
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
}
