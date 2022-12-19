using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day6
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day6\\Day6.txt");
            string sOneLine = sText[0];
            int nSignal = 14; // 4 for part1

            string sCheck = sOneLine.Substring(0, nSignal);

            int nCheck = GetNumber(sCheck);

            if (nCheck == nSignal)
            {
                Console.WriteLine(nSignal);
                return;
            }

            for(int i = nSignal; i < sOneLine.Length; i++)
            {
                sCheck = sCheck.Substring(1, nSignal - 1);
                char cLetter = sOneLine[i];
                sCheck += cLetter;

                if (GetNumber(sCheck) == nSignal)
                {
                    Console.WriteLine(i+1);
                    break;
                }


            }
        }

        private int GetNumber(string sCheck)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            foreach (char c in sCheck)
            {
                if (keyValuePairs.TryGetValue(c, out int value) == false)
                {
                    keyValuePairs.Add(c, value);
                }
            }

            return keyValuePairs.Count;
        }
    }
}
