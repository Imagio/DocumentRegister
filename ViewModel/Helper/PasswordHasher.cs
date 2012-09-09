using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Docs.ViewModel
{
    public static class PasswordHasher
    {
        public static string Calc(string pwd)
        {
            if (pwd == null)
                return null;
            MD5 md5 = MD5.Create();
            var input = Encoding.ASCII.GetBytes(pwd);
            var result = md5.ComputeHash(input);
            StringBuilder sb = new StringBuilder(result.Length * 2);
            sb.Append("#");
            foreach (byte b in result)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString().ToUpper();
        }
    }
}
