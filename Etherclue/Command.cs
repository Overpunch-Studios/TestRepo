using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etherclue
{
    class Command
    {
        Encryption encryption = new Encryption();
        string commandEncrypted;
        string commandDecrypted;

        public Command(string cmd, bool send)
        {
            if (!send)
            {
                commandEncrypted = cmd;
                commandDecrypted = Decrypt();
            }
            else
            {
                commandDecrypted = cmd;
                commandEncrypted = Encrypt();
            }
        }

        private string Decrypt()
        {
            string pass = Program.cyphertext;
            string part1of3 = encryption.DecryptString(commandEncrypted, Encoding.Default.GetBytes(pass));
            string token = part1of3.Split(';')[1];
            string part2of3 = part1of3.Split(';')[0];
            string part3of3 = encryption.DecryptString(part2of3, Encoding.Default.GetBytes(token));
            return part3of3;
        }

        private string Encrypt()
        {
            string pass = Program.cyphertext;
            string token = encryption.GenerateKey(16);
            string part1of3 = encryption.EncryptString(commandDecrypted, Encoding.Default.GetBytes(token));
            string part2of3 = part1of3 += ";" + token;
            string part3of3 = encryption.EncryptString(part2of3, Encoding.Default.GetBytes(pass));
            return part3of3;
        }

        public string GottenRequest()
        {
            return commandDecrypted;
        }

        public string SendRequest()
        {
            return commandEncrypted;
        }
    }
}
