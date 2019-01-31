using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cat.Core.Encrypts
{
    public static class Encrypt
    {
        public static string ToMD5(this string str)
        {
            string strResult = string.Empty;

            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                strResult = BitConverter.ToString(result).Replace("-", "");
            }

            return strResult;
        }
    }
}
