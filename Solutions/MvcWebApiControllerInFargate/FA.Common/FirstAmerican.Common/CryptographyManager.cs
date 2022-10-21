using FirstAmerican.Common.Properties;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FirstAmerican.Common
{
    public static class CryptographyManager
    {
        private const int DEFAULT_SALT_LENGTH = 16;
        private const int BUFFER_SIZE = 4096;

        public static int DefaultSaltLength
        {
            get
            {
                return 16;
            }
        }

        public static int BufferSize
        {
            get
            {
                return 4096;
            }
        }

        public static string Encrypt(string dataToEncrypt, string SecretKey, string SecretIV)
        {
            string Encrypt = EncryptSymmetric(SymmetricAlgorithmType.Rijndael, System.Convert.FromBase64String(SecretKey), System.Convert.FromBase64String(SecretIV), dataToEncrypt);
            Encrypt = Encrypt.Replace("/", "cypt").Replace("+", "eypt");
            return Encrypt;
        }

        public static string DecryptText(string encryptedString, string cipherKey, string cipherIV)
        {
            if (IsBase64String(encryptedString))
            {
                try
                {
                    if (!string.IsNullOrEmpty(cipherKey) && !string.IsNullOrEmpty(cipherIV))
                    {
                        //Local Variable Declaration to store decrypted value
                        string decryptedData;

                        //Generating Salt Value
                        byte[] salt = cipherIV.Split(',').Select(n => Convert.ToByte(n, 16)).ToArray();

                        //Setting up the Decryptor using RijndaelManaged Class
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(cipherKey, salt);
                        using (RijndaelManaged RMCrypto = new RijndaelManaged())
                        {
                            RMCrypto.Key = pdb.GetBytes(32);
                            RMCrypto.IV = pdb.GetBytes(16);
                            var decryptor = RMCrypto.CreateDecryptor(RMCrypto.Key, RMCrypto.IV);
                            var cipher = Convert.FromBase64String(encryptedString);

                            //Decrypting the text read into a memory stream
                            using (var msDecrypt = new MemoryStream(cipher))
                            {
                                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    using (var srDecrypt = new StreamReader(csDecrypt))
                                    {
                                        decryptedData = srDecrypt.ReadToEnd();
                                    }
                                }
                            }
                            return decryptedData;
                        }
                    }
                    else
                    {
                        throw new Exception("FAFRijndael EncryptText() - Key/IV is null.");
                    }
                }
                catch (CryptographicException)
                {
                    //LogError("Error occurred during FAFRijndael DecryptText() - ", ex);
                    return "";
                }
                catch (Exception)
                {
                    //LogError("Error occurred during FAFRijndael EncryptText() - ", ex);
                    return "";
                }
            }
            else
            {
                //LogError("The Encrypted Data is not Base64 encoded.The Input Data is:" + encryptedString);
                return encryptedString;
            }
        }

        private static bool IsBase64String(string text)
        {
            text = text.Trim();
            if (text.Length % 4 == 0)
            {
                try
                {
                    byte[] test = Convert.FromBase64String(text);
                    return true;
                }
                catch (Exception)
                {
                    //LogError("The Encrypted Data is not Base64 encoded.The Input Data is:" + text);
                    return false;
                }
            }
            else return false;
        }

        public static string EncryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, string dataToEncrypt)
        {
            ParameterValidator.VerifyStringParameter("dataToEncrypt", dataToEncrypt, false, false, null, null);
            byte[] inArray = CryptographyManager.EncryptSymmetric(algorithmType, key, iv, Encoding.ASCII.GetBytes(dataToEncrypt));
            return Convert.ToBase64String(inArray);
        }

        public static byte[] EncryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, byte[] dataToEncrypt)
        {
            ParameterValidator.VerifyParameterIsNotNull("key", key, null);
            ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
            ParameterValidator.VerifyParameterIsNotNull("dataToEncrypt", dataToEncrypt, null);
            byte[] result;
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType, key, iv))
            {
                ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }

        public static void EncryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, Stream dataToEncrypt, Stream encryptedData)
        {
            ParameterValidator.VerifyParameterIsNotNull("key", key, null);
            ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
            ParameterValidator.VerifyParameterIsNotNull("dataToEncrypt", dataToEncrypt, null);
            ParameterValidator.VerifyParameterIsNotNull("encryptedData", encryptedData, null);
            byte[] array = new byte[4096];
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType, key, iv))
            {
                ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(encryptedData, transform, CryptoStreamMode.Write);
                for (int i = dataToEncrypt.Read(array, 0, array.Length); i > 0; i = dataToEncrypt.Read(array, 0, array.Length))
                {
                    cryptoStream.Write(array, 0, i);
                }
                cryptoStream.FlushFinalBlock();
            }
        }

        public static string DecryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, string base64DataToDecrypt)
        {
            ParameterValidator.VerifyStringParameter("base64DataToDecrypt", base64DataToDecrypt, false, false, null, null);
            byte[] dataToDecrypt = Convert.FromBase64String(base64DataToDecrypt);
            byte[] bytes = CryptographyManager.DecryptSymmetric(algorithmType, key, iv, dataToDecrypt);
            return Encoding.ASCII.GetString(bytes);
        }

        public static byte[] DecryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, byte[] dataToDecrypt)
        {
            ParameterValidator.VerifyParameterIsNotNull("key", key, null);
            ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
            ParameterValidator.VerifyParameterIsNotNull("dataToDecrypt", dataToDecrypt, null);
            byte[] array = new byte[dataToDecrypt.Length];
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType, key, iv))
            {
                ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor();
                using (MemoryStream memoryStream = new MemoryStream(dataToDecrypt))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
                    {
                        int newSize = cryptoStream.Read(array, 0, array.Length);
                        Array.Resize<byte>(ref array, newSize);
                    }
                }
            }
            return array;
        }

        public static void DecryptSymmetric(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv, Stream dataToDecrypt, Stream decryptedData)
        {
            ParameterValidator.VerifyParameterIsNotNull("key", key, null);
            ParameterValidator.VerifyParameterIsNotNull("iv", iv, null);
            ParameterValidator.VerifyParameterIsNotNull("dataToDecrypt", dataToDecrypt, null);
            ParameterValidator.VerifyParameterIsNotNull("decryptedData", decryptedData, null);
            byte[] array = new byte[4096];
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType, key, iv))
            {
                ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(dataToDecrypt, transform, CryptoStreamMode.Read);
                for (int i = cryptoStream.Read(array, 0, array.Length); i > 0; i = cryptoStream.Read(array, 0, array.Length))
                {
                    decryptedData.Write(array, 0, i);
                }
            }
        }

        public static byte[] GenerateSymmetricKey(SymmetricAlgorithmType algorithmType)
        {
            byte[] key;
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType))
            {
                symmetricAlgorithm.GenerateKey();
                key = symmetricAlgorithm.Key;
            }
            return key;
        }

        public static byte[] GenerateSymmetricIV(SymmetricAlgorithmType algorithmType)
        {
            byte[] iV;
            using (SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType))
            {
                symmetricAlgorithm.GenerateIV();
                iV = symmetricAlgorithm.IV;
            }
            return iV;
        }

        public static string CreateHash(HashAlgorithmType algorithmType, string dataToHash)
        {
            ParameterValidator.VerifyStringParameter("dataToHash", dataToHash, true, false, null, null);
            byte[] bytes = Encoding.ASCII.GetBytes(dataToHash);
            byte[] inArray = CryptographyManager.CreateHash(algorithmType, bytes);
            return Convert.ToBase64String(inArray);
        }

        public static byte[] CreateHash(HashAlgorithmType algorithmType, byte[] dataToHash)
        {
            ParameterValidator.VerifyParameterIsNotNull("dataToHash", dataToHash, null);
            byte[] result;
            using (HashAlgorithm hashAlgorithm = CryptographyManager.CreateHashAlgorithm(algorithmType))
            {
                result = hashAlgorithm.ComputeHash(dataToHash);
            }
            return result;
        }

        public static byte[] CreateHash(HashAlgorithmType algorithmType, Stream dataToHash)
        {
            ParameterValidator.VerifyParameterIsNotNull("dataToHash", dataToHash, null);
            byte[] result;
            using (HashAlgorithm hashAlgorithm = CryptographyManager.CreateHashAlgorithm(algorithmType))
            {
                result = hashAlgorithm.ComputeHash(dataToHash);
            }
            return result;
        }

        public static bool CompareAgainstHash(HashAlgorithmType algorithmType, string plainValue, string base64HashValue)
        {
            ParameterValidator.VerifyStringParameter("plainValue", plainValue, true, false, null, null);
            ParameterValidator.VerifyStringParameter("base64HashValue", base64HashValue, false, false, null, null);
            byte[] bytes = Encoding.ASCII.GetBytes(plainValue);
            byte[] hashValue = Convert.FromBase64String(base64HashValue);
            return CryptographyManager.CompareAgainstHash(algorithmType, bytes, hashValue);
        }

        public static bool CompareAgainstHash(HashAlgorithmType algorithmType, byte[] plainValue, byte[] hashValue)
        {
            ParameterValidator.VerifyParameterIsNotNull("plainValue", plainValue, null);
            ParameterValidator.VerifyParameterIsNotNull("hashValue", hashValue, null);
            byte[] array = CryptographyManager.CreateHash(algorithmType, plainValue);
            if (array.Length != hashValue.Length)
            {
                return false;
            }
            bool result = true;
            for (int i = 0; i < hashValue.Length; i++)
            {
                if (hashValue[i] != array[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool CompareAgainstHash(HashAlgorithmType algorithmType, Stream plainValue, byte[] hashValue)
        {
            ParameterValidator.VerifyParameterIsNotNull("plainValue", plainValue, null);
            ParameterValidator.VerifyParameterIsNotNull("hashValue", hashValue, null);
            byte[] array = CryptographyManager.CreateHash(algorithmType, plainValue);
            if (array.Length != hashValue.Length)
            {
                return false;
            }
            bool result = true;
            for (int i = 0; i < hashValue.Length; i++)
            {
                if (hashValue[i] != array[i])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static byte[] GenerateSalt()
        {
            return CryptographyManager.GenerateSalt(16);
        }

        public static byte[] GenerateSalt(int saltSize)
        {
            ParameterValidator.VerifyParameterWithComparison<int>("saltSize", saltSize, ComparisonType.GreaterThan, 0, null);
            byte[] array = new byte[saltSize];
            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(array);
            }
            return array;
        }

        private static SymmetricAlgorithm CreateSymmetricAlgorithm(SymmetricAlgorithmType algorithmType, byte[] key, byte[] iv)
        {
            SymmetricAlgorithm symmetricAlgorithm = CryptographyManager.CreateSymmetricAlgorithm(algorithmType);
            symmetricAlgorithm.Key = key;
            symmetricAlgorithm.IV = iv;
            return symmetricAlgorithm;
        }

        private static SymmetricAlgorithm CreateSymmetricAlgorithm(SymmetricAlgorithmType algorithmType)
        {
            SymmetricAlgorithm symmetricAlgorithm;
            switch (algorithmType)
            {
                case SymmetricAlgorithmType.Rijndael:
                    symmetricAlgorithm = new RijndaelManaged();
                    break;

                default:
                    throw new NotSupportedException(string.Format(ErrorResources.Culture, ErrorResources.SYMMETRIC_ALGORITHM_NOT_SUPPORTED, new object[]
                    {
                    algorithmType
                    }));
            }
            symmetricAlgorithm.Mode = CipherMode.CBC;
            return symmetricAlgorithm;
        }

        private static HashAlgorithm CreateHashAlgorithm(HashAlgorithmType algorithmType)
        {
            HashAlgorithm result;
            switch (algorithmType)
            {
                case HashAlgorithmType.SHA256:
                    result = SHA256.Create();
                    break;

                case HashAlgorithmType.SHA384:
                    result = SHA384.Create();
                    break;

                case HashAlgorithmType.SHA512:
                    result = SHA512.Create();
                    break;

                default:
                    throw new NotSupportedException(string.Format(ErrorResources.Culture, ErrorResources.HASH_ALGORITHM_NOT_SUPPORTED, new object[]
                    {
                    algorithmType
                    }));
            }
            return result;
        }
    }
}
