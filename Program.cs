using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Encryption encryption = new Encryption();
            string keyPhrase = "n3SqDL2K9mJuLfmS";
            string text = "Hello World";
            string encrypted = encryption.EncryptString(text, Encoding.Default.GetBytes(keyPhrase));
            string decrypted = encryption.DecryptString(encrypted, Encoding.Default.GetBytes(keyPhrase));

            Console.WriteLine("Original: {0}", text);
            Console.WriteLine("Encrypted: {0}", encrypted);
            Console.WriteLine("Decrypted: {0}", decrypted);
            Console.ReadLine();
        }
    }
}
