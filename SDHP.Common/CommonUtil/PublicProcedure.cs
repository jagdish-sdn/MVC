using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SDHP.Common
{
    public class PublicProcedure
    {
        public enum GUIDExtraction
        {
            AlphaNumbers = 1,
            OnlyAlphabets = 2,
            OnlyNumbers = 3
        }
        private static string CharString = "abcdefghijklmnopqrstuvwxyz";
        private static string NumberString = "0123466789";
        public static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key,byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        public static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream

                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
        private static string ExtractCharacter(string value)
        {
            return new string(value.Where(c => (!char.IsDigit(c) && (((int)c >= 65 && (int)c <= 90) || ((int)c >= 97 && (int)c <= 122)))).ToArray());
        }
        /// <summary>
        /// Static method to extract only numbers from Value string.
        /// </summary>
        /// <param name="value">String from which digits will be extracted</param>
        /// <returns></returns>
        private static string ExtractDigits(string value)
        {
            return new string(value.Where(c => char.IsDigit(c)).ToArray());
        }
        /// <summary>
        /// This method generates the GUID string.
        /// </summary>
        /// <returns></returns>
        public static string GenerateGUID(GUIDExtraction extraction = GUIDExtraction.AlphaNumbers, int? length = 10)
        {
            //  Get the current system datetime to manipulate the GUID.
            string currentDatetime = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

            Random rnd = new Random();
            //  Shuffle the generated GUID by using system datatime.
            currentDatetime = new string(currentDatetime.ToCharArray().OrderBy(x => rnd.Next()).ToArray());

            //  Concat the actual System generate GUID.
            currentDatetime += Guid.NewGuid().ToString("N");

            //  Shuffel the new generated GUID.
            string NewString = new string(currentDatetime.ToCharArray().OrderBy(x => rnd.Next()).ToArray());
            NewString = NewString.Substring(0, length ?? NewString.Length);
            switch (extraction)
            {
                case GUIDExtraction.OnlyAlphabets:
                    NewString = ExtractCharacter(NewString);
                    if (length != null && NewString.Length > length.Value)
                    {
                        NewString = NewString.Substring(0, length.Value);
                    }
                    else if (length != null)
                    {
                        if (NewString.Length != length.Value)
                        {
                            do
                            {
                                NewString += new string(CharString.ToCharArray().OrderBy(x => rnd.Next()).ToArray());
                                NewString = NewString.Substring(0, length.Value);
                            } while (NewString.Length != length.Value);
                        }
                    }

                    break;
                case GUIDExtraction.OnlyNumbers:
                    NewString = ExtractDigits(NewString);
                    if (length != null && NewString.Length > length.Value)
                    {
                        NewString = NewString.Substring(0, length.Value);
                    }
                    else if (length != null)
                    {
                        if (NewString.Length != length.Value)
                        {
                            do
                            {
                                NewString += new string(NumberString.ToCharArray().OrderBy(x => rnd.Next()).ToArray());
                                NewString = NewString.Substring(0, length.Value);
                            } while (NewString.Length != length.Value);
                        }
                    }
                    break;
            }
            return NewString;
        }
    }
}
