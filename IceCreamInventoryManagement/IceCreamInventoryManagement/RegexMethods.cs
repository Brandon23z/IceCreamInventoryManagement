using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IceCreamInventoryManagement
{
    class RegexMethods
    {
        public static regexClass checkRegex(string input, string regex)
        {
            string output = "";
            Match match = Regex.Match(input, regex);
            if (match.Success)
            {
                List<string> values = new List<string>();
                foreach (Group g in match.Groups)
                {
                    values.Add(g.Value);
                }
                return new regexClass(values);
            }
            else
            {
                return new regexClass(false);
            }
        }

        public class regexClass
        {
            public bool valid;
            public List<string> groupValues;

            public regexClass(bool _valid)
            {
                valid = _valid;
            }

            public regexClass(List<string> values)
            {
                groupValues = values;
                valid = true;
            }
        }
    }
}
