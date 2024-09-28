using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprLib
{
    internal class Coder : ICoder
    {
        readonly Dictionary<string, int> romanDigitsSimple =
        new Dictionary<string, int> {
            { "I", 1 },
            { "IV", 4 },
            { "V", 5 },
            { "IX", 9 },
            { "X", 10 },
            { "XL", 40 },
            { "L", 50 },
            { "XC", 90 },
            { "C", 100 },
            { "CD", 400 },
            { "D", 500 },
            { "CM", 900 },
            { "M", 1000 }
        };
        public int Decode(string s)
        {
            if (int.TryParse(s, out int result))
            {
                return result;
            }
            else
            {
                int len = s.Length - 1;
                if (len == 0)
                {
                    return romanDigitsSimple[s];
                }
                string nexts = s;
                for (int i = 0; i < len; i++)
                {
                    string key = s.Substring(i, 2);
                    if (romanDigitsSimple.ContainsKey(key))
                    {
                        result += romanDigitsSimple[key];
                        nexts = nexts.Remove(i, 2).Insert(i, "@@");
                        i++;
                    }
                }
                int len2 = nexts.Length;
                if (len2 == 1)
                {
                    return result + romanDigitsSimple[nexts];
                }
                for (int i = 0; i < len2; i++)
                {
                    string key = nexts.Substring(i, 1);
                    if (romanDigitsSimple.ContainsKey(key))
                    {
                        result += romanDigitsSimple[key];
                    }
                }
                return result;
            }
        }

        public string Encode(int d)
        {
            string result = "";
            var items = romanDigitsSimple.OrderByDescending(d => d.Value).ToList();
            foreach (KeyValuePair<string, int> item in items)
            {
                int scount = d / item.Value;
                for (int i = 0; i < scount; i++)
                {
                    result += item.Key;
                }
                d = d - (scount * item.Value);
            }
            return result;
        }
    }
}
