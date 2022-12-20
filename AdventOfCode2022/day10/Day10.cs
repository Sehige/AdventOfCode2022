using System;
using System.Collections.Generic;
using System.Text;

namespace day10
{
    internal class Day10
    {
        public int nFreq = 1;
        public int nPosSprite = 1;
        public int nCycle = 0;
        public int nTotal = 0;
        /// Part 1 = 20, Part 2 = 40
        public int nCycleMilestone = 40;

        public char[,] cScreen = new char[7,41];
        public int nRow = 0;    

        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day10\\Day10.txt");

            foreach(string s in sText)
            {
                /// Part1(s);

                /// Part2(s);
            }

            /// Part1
            Console.WriteLine(nTotal);

            ///Part2
            for(int i = 0; i < 6; i++)
            {
                Console.WriteLine();
                for(int j = 0; j < 40; j++)
                {
                    Console.Write(cScreen[i,j]);
                }
            }
        }

        private void Part2(string s)
        {
            string sAction = s.Split(' ')[0];

            WriteScreen();

            nCycle++;
            if (nCycle == nCycleMilestone)
            {
                nRow++;
                nCycle = 0;
                if (nRow == 7) return;
            }
            if (sAction == "noop")
            {
            }
            else
            {
                int nNumber = int.Parse(s.Split(' ')[1]);

                WriteScreen();

                nCycle++;
                if (nCycle == nCycleMilestone)
                {
                    nRow++;
                    nCycle = 0;
                    if (nRow == 7) return;
                }

                nFreq += nNumber;
            }
        }

        private void WriteScreen()
        {
            if (nCycle == nFreq - 1 || nCycle == nFreq || nCycle == nFreq + 1)
            {
                cScreen[nRow, nCycle ] = '#';
            }
            else
            {
                cScreen[nRow, nCycle] = '.';
            }
        }

        private void Part1(string s)
        {
            if (nCycleMilestone == 260) return;

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

        private void CalculateTotal()
        {
            nTotal += nCycleMilestone * nFreq;
            nCycleMilestone += 40;
            Console.WriteLine("X = {0}, signal = {1}", nFreq, nTotal);
        }
    }
}
