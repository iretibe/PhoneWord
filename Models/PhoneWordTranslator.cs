using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Models
{
    public static class PhoneWordTranslator
    {
        private static string[] digits =
        {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return null;
            }

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder();

            foreach (var c in raw)
            {
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                else
                {
                    var result = TranslateToNumber(c, 2);

                    if (result != null)
                    {
                        newNumber.Append(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return newNumber.ToString();
        }

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        private static int? TranslateToNumber(char c, int v)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                {
                    return 2 + i;
                }                
            }

            return null;
        }
    }
}
