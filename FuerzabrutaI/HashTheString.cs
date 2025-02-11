using System.Security.Cryptography;
using System.Text;

namespace FuerzabrutaI;

class HashTheString(ArrayToString aas)
{
    public String hashTheString(String toString)
    {
        // Convierte la cadena de texto en un arreglo de bytes usando codificación ASCII.
        byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(toString);

        // Aplica el algoritmo MD5 al arreglo de bytes y lo convierte a una cadena hexadecimal.
        return aas.arrayToString(new MD5CryptoServiceProvider().ComputeHash(tmpSource));
    }
}