using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.FlyWeight.First_Example
{
    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public static List<string> Strings = strings;

        public User2(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1) return idx;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }
}
