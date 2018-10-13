using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string cryptoLine = null;

            for (int i = 0; i < lines; i++)
            {
                cryptoLine += Console.ReadLine();
            }

            string pattern = @"(\{.*?\})|(\[.*?\])";

            MatchCollection matches = Regex.Matches(cryptoLine, pattern);


            string digitPattern = @"[0-9]{3}";

            List<string> validBlocks = new List<string>();

            foreach(var match in matches)
            {
                validBlocks.Add(match.ToString());
            }

            Dictionary<string, int> validNumbers = new Dictionary<string, int>();

            for(int i = 0; i < validBlocks.Count; i++)
            {
                string cryptoBlock = validBlocks[i];

                MatchCollection numM = Regex.Matches(cryptoBlock, digitPattern);
                string number = null;

                foreach(var num in numM)
                {
                    number += num.ToString();
                }

                if(number.Length % 3 == 0)
                {
                    validNumbers.Add(number, cryptoBlock.Length);
                }
            }

            string output = null;

            foreach(var pairs in validNumbers)
            {
                string num = pairs.Key;

                MatchCollection threes = Regex.Matches(num, digitPattern);

                foreach(var character in threes)
                {
                    output = output + (char)((int.Parse(character.ToString())) - pairs.Value);
                }
            }

            Console.WriteLine(output);
        }
    }
}
