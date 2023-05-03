using System;
using System.Collections.Generic;
using System.Text;
using static AdventOfCode2022.Day7;

namespace AdventOfCode
{
    internal  class Day12
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day12\\Day12.txt");

            int[,] posStart = new int[5, 8];
            int nStartX = 0;
            int nStartY = 0;
            int[,] posGoal = new int[5, 8];
            int nGoalX = 0;
            int nGoalY = 0;
            int[,] map = new int[5, 8];
            List<int[,]> listPaths = new List<int[,]>();
            int[,] search = new int[5, 8];

            for (int i = 0; i < sText.Length; i++)
            {
                string s = sText[i];
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == 'S')
                    {
                        map[i, j] = 1;
                        posStart[i, j] = 1;
                        nStartX = i; nStartY = j;
                    }
                    else if (s[j] == 'E')
                    {
                        map[i, j] = 26;
                        posGoal[i, j] = 26;
                        nGoalX = i; nGoalY = j;
                    }
                    else map[i, j] = (int)(s[j]) - 96; 
                    Console.Write(s[j]);
                }
                Console.WriteLine();
            }

            bool bSearchPath = true;


            while (bSearchPath)
            {

            }
        }
    }
}
