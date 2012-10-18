using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using DomainService.DomainModels;

namespace PresentationService.Helpers
{
    public static class PasswordHashHelper
    {
        public static string HashPassword(string password)
        {
            var salt = GetRandomSalt();
            var hash = Sha256Hex(salt + password);
            return salt + hash;
        }

        public static bool ValidatePassword(RegisteredUser user, string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var salt = user.Password.Substring(0, 16);
            var validHash = user.Password.Substring(16, 64);
            var passHash = Sha256Hex(salt + password);
            var isValid = string.CompareOrdinal(validHash, passHash) == 0;

            return isValid;
        }

        private static string GetRandomSalt()
        {
            using (var random = new RNGCryptoServiceProvider())
            {
                var salt = new byte[8];
                random.GetBytes(salt);
                return BytesToHex(salt);
            }
        }

        private static string Sha256Hex(string toHash)
        {
            using (var hash = new SHA256Managed())
            {
                var utf8 = Encoding.UTF8.GetBytes(toHash);
                return BytesToHex(hash.ComputeHash(utf8));
            }
        }

        private static string BytesToHex(ICollection<byte> toConvert)
        {
            var s = new StringBuilder(toConvert.Count * 2);
            foreach (var b in toConvert)
            {
                s.Append(b.ToString("x2", CultureInfo.InvariantCulture));
            }

            return s.ToString();
        }
    }
}
