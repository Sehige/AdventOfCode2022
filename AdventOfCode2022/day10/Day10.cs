using System;
using System.Collections.Generic;
using System.Text;

namespace day10
{
    internal class Day10
    {
        public int nFreq = 1;
        public int nCycle = 0;
        public int nTotal = 0;
        public int nCycleMilestone = 20;

        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day10\\Day10.txt");

            foreach(string s in sText)
            {
                if (nCycleMilestone == 260) break;

                string sAction = s.Split(' ')[0];

                nCycle++;
                if (sAction == "noop")
                {
                }
                else
                {
                    int nNumber = int.Parse(s.Split(' ')[1]);

                    if (nCycle == nCycleMilestone)
                    {
                        CalculateTotal();
                    }
                    nCycle++;

                    if (nCycle == nCycleMilestone)
                    {
                        CalculateTotal();
                    }
                    nFreq += nNumber;
                }

                if (nCycle == nCycleMilestone)
                {
                    CalculateTotal();
                }
            }

           Console.WriteLine(nTotal);
        }

        private void CalculateTotal()
        {
            nTotal += nCycleMilestone * nFreq;
            nCycleMilestone += 40;
            Console.WriteLine("X = {0}, signal = {1}", nFreq, nTotal);
        }
    }
}
