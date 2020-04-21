using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymetriskKrypteringRSAmodtager
{
    public class RSAWithXMLKey
    {

        public string DecryptfromXml(byte[] texttodecrypt)
        {
            var rsa = new RSAWithXMLKey();

            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            // dekrypter hex-streng
            var decrypted = rsa.DecryptData(privateKeyPath, texttodecrypt);

            return Encoding.Default.GetString(decrypted);

        }

        public void UpdateRsaKeys()
        {
            var rsa = new RSAWithXMLKey();

            const string publicKeyPath = "c:\\temp\\publickey.xml";
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            // updater modulus/exponent
            rsa.AssignNewKey(publicKeyPath, privateKeyPath);

        }

        public byte[] GetPrivateData_D()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var D = parameters.D;


                return D;
            }
        }

        public byte[] GetPrivateData_Dp()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var Dp = parameters.DP;


                return Dp;
            }
        }

        public byte[] GetPrivateData_Dq()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var Dq = parameters.DQ;


                return Dq;
            }
        }

        public byte[] GetPrivateData_InverseQ()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var InverseQ = parameters.InverseQ;

                return InverseQ;
            }
        }

        public byte[] GetPrivateData_P()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var P = parameters.P;

                return P;
            }
        }

        public byte[] GetPrivateData_Q()
        {
            var rsa = new RSAWithXMLKey();
            const string privateKeyPath = "c:\\temp\\privatekey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                Rsa.FromXmlString(File.ReadAllText(privateKeyPath));

                var parameters = Rsa.ExportParameters(true);
                var Q = parameters.Q;

                return Q;
            }
        }
        public byte[] GetModulus()
        {
            var rsa = new RSAWithXMLKey();
            const string publicKeyPath = "c:\\temp\\publickey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;

                // læs data fra c:\\temp\\publickey.xml
                Rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                // expoter modulus fra provider og retuner den
                var parameters = Rsa.ExportParameters(false);
                var modulus = parameters.Modulus;

                return modulus;
            }
        }

        public byte[] GetExponent()
        {
            var rsa = new RSAWithXMLKey();
            const string publicKeyPath = "c:\\temp\\publickey.xml";

            using (var Rsa = new RSACryptoServiceProvider(2048))
            {
                Rsa.PersistKeyInCsp = false;
                // læs data fra c:\\temp\\publickey.xml
                Rsa.FromXmlString(File.ReadAllText(publicKeyPath));

                // expoter exponent fra provider og retuner den
                var parameters = Rsa.ExportParameters(false);
                var exponent = parameters.Exponent;

                return exponent;
            }
        }

        public void AssignNewKey(string publicKeyPath, string privateKeyPath)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {

                rsa.PersistKeyInCsp = false;

                //if (File.Exists(privateKeyPath))
                //{
                //    File.Delete(privateKeyPath);
                //}

                //if (File.Exists(publicKeyPath))
                //{
                //    File.Delete(publicKeyPath);
                //}

                var publicKeyfolder = Path.GetDirectoryName(publicKeyPath);
                var privateKeyfolder = Path.GetDirectoryName(privateKeyPath);

                if (!Directory.Exists(publicKeyfolder))
                {
                    Directory.CreateDirectory(publicKeyfolder);
                }

                if (!Directory.Exists(privateKeyfolder))
                {
                    Directory.CreateDirectory(privateKeyfolder);
                }

                // skriv rsa object til vores public/private xml filer
                File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));
                File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));
            }
        }

        public byte[] DecryptData(string privateKeyPath, byte[] dataToEncrypt)
        {
            byte[] plain;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                // læs private key og dekrypter bagefter, retuner plaintekst som byte array
                rsa.FromXmlString(File.ReadAllText(privateKeyPath));
                plain = rsa.Decrypt(dataToEncrypt, false);
            }

            return plain;
        }

    }
}
