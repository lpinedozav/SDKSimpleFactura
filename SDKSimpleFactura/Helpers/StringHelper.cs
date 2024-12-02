using System;
namespace SDKSimpleFactura.Helpers
{
    public static class StringHelper
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            // if (value.Length > maxLength)
            //     Console.WriteLine(String.Format("Truncate performed: {0} to {1}", value, value.Substring(0, maxLength)));
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
        public static string GenerateRandomString(int length)
        {
            Random Random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] word = new char[length];

            for (int i = 0; i < length; i++)
            {
                word[i] = chars[Random.Next(chars.Length)];
            }

            return new string(word);
        }
    }
}
