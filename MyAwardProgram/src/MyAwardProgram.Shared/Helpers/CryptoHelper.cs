using MyAwardProgram.Shared.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MyAwardProgram.Shared.Helpers
{
    public class CryptoHelper : ICryptoHelper
    {
        private readonly HashAlgorithm _algorithm = SHA512.Create();

        public string GenerateHash(string password)
        {
            byte[] codifiedValue = Encoding.UTF8.GetBytes(password);
            byte[] hashedPassword = _algorithm.ComputeHash(codifiedValue);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte character in hashedPassword)
            {
                stringBuilder.Append(character.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        public bool VerifyHash(string typedPassword, string registeredPassword)
        {
            byte[] hashedPassword = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(typedPassword));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte character in hashedPassword)
            {
                stringBuilder.Append(character.ToString("X2"));
            }

            return stringBuilder.ToString() == registeredPassword;
        }       
    }
}
