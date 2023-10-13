using System;
using System.Text;
using System.Security.Cryptography;
namespace MachinesAndRobotsVKR
{
    public static class md5
    {
        public static string password = "";
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}
