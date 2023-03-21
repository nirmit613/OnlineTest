using OnlineTest.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace OnlineTest.Services.Services
{
    public class HasherService:IHasherService
    {
        public string Hash(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            string hashString = string.Empty;
            using (var sha = SHA512.Create())
            {
                byte[] hash = sha.ComputeHash(inputBytes);
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
            }
            return hashString;
        }
    }
}
