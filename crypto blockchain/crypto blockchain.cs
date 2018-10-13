using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace crypto_blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string crypto = "";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();


                sb.Append(input);
            }

            crypto = sb.ToString();

            string regOne = @"(\{.*?\})";
            string regTwo = @"(\[.*?\])";
            MatchCollection matchesOne = Regex.Matches(crypto, regOne);
            MatchCollection matchesTwo = Regex.Matches(crypto, regTwo);

            List<string> crypts = new List<string>();

            foreach(var match in matchesOne)
            {
                crypts.Add(match.ToString());
            }

            foreach(var match in matchesTwo)
            {
                crypts.Add(match.ToString());
            }

            

            List<string> digits = new List<string>();

            string output = "";

            foreach(string cryptoBlock in crypts)
            {
                string patter = @"d*";
                string number = "";

                number = Regex.Match(cryptoBlock, patter).ToString();

                if(number.Length % 3 == 0)
                {
                    string numPat = @"[0-9]{3}";


                    MatchCollection numMatch = Regex.Matches(number, numPat);

                    foreach(var match in numMatch)
                    {
                        int num = int.Parse(match.ToString());
                        char c = (char)num;
                        output += c;
                    }
                }

                

            }

            Console.WriteLine(output);
        }
    }
}
