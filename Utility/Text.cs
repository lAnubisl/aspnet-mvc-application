using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class Text
    {
        public static string Md5Hash(this string value)
        {
            var hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedDataBytes = hasher.ComputeHash(encoder.GetBytes(value));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}
