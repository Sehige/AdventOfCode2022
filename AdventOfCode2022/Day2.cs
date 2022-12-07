using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day2
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\Data\\Day2.txt");

            int nPoints = 0;
            foreach (string s in sText)
            {
                string sOpponent = s.Split(' ')[0];
                string sMe = s.Split(" ")[1];

                nPoints += ReturnWinnerPart2(sOpponent, sMe);
            }

            Console.WriteLine(nPoints);
        }

        private int ReturnWinnerPart1(string sOpponent, string sMe)
        {
            int nPoints = 0;

            if (sOpponent == "A" && sMe == "X" || sOpponent == "B" && sMe == "Y" || sOpponent == "C" && sMe == "Z")
            {
                nPoints = 3;
            }
            else if (sOpponent == "A" && sMe == "Z" || sOpponent == "B" && sMe == "X" || sOpponent == "C" && sMe == "Y")
            {
                nPoints = 0;
            }
            else
            {
                nPoints = 6;
            }

            if (sMe == "X") nPoints += 1;
            else if (sMe == "Y") nPoints += 2;
            else nPoints += 3;

            return nPoints;
        }

        private int ReturnWinnerPart2(string sOpponent, string sMe)
        {
            int nPoints = 0;

            switch (sMe)
            {
                case "X":
                    nPoints = 0;
                    switch (sOpponent)
                    {
                        case "A":
                            nPoints += 3;
                            break;
                        case "B":
                            nPoints += 1;
                            break;
                        case "C":
                            nPoints += 2;
                            break;
                    }
                    break;
                case "Y":
                    nPoints = 3;
                    switch (sOpponent)
                    {
                        case "A":
                            nPoints += 1;
                            break;
                        case "B":
                            nPoints += 2;
                            break;
                        case "C":
                            nPoints += 3;
                            break;
                    }
                    break;
                case "Z":
                    nPoints = 6;
                    switch (sOpponent)
                    {
                        case "A":
                            nPoints += 2;
                            break;
                        case "B":
                            nPoints += 3;
                            break;
                        case "C":
                            nPoints += 1;
                            break;
                    }
                    break;
            }

            return nPoints;
        }
    }
}
