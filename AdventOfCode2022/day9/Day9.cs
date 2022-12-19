using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AdventOfCode2022
{
    public partial class Day9
    {
        public void Run()
        {
            SetData();
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day9\\Day9.txt");

            int nPath = 1;

            foreach (string s in sText)
            {
                string sDirection = s.Split(' ')[0];
                int nSteps = int.Parse(s.Split(' ')[1]);

                for (int i = 0; i < nSteps; i++)
                {
                    switch (sDirection)
                    {
                        case "R":
                            listH[1]++;
                            break;
                        case "L":
                            listH[1]--;
                            break;
                        case "U":
                            listH[0]--;
                            break;
                        case "D":
                            listH[0]++;
                            break;
                    }

                    ///Check Diff
                    for (int j = 0; j < keyData.Count - 1; j++)
                    {
                        List<int> listHead = new List<int>();
                        listHead = keyData[j];

                        List<int> listTail = new List<int>();
                        listTail = keyData[j + 1];

                        if (Math.Abs(listHead[0] - listTail[0]) == 2)
                        {
                            MoveX(ref listHead, ref listTail);

                            //listT = new List<int>(listPrevH);
                            //Console.WriteLine(listT[0] + "," + listT[1]);
                        }
                        else if (Math.Abs(listHead[1] - listTail[1]) == 2)
                        {
                            MoveY(ref listHead, ref listTail);

                            //listT = new List<int>(listPrevH);
                            //Console.WriteLine(listT[0]+ "," + listT[1]);
                        }
                    }

                    if (arrayPath[keyData[9][0], keyData[9][1]] == 0)
                    {
                        arrayPath[keyData[9][0], keyData[9][1]] = 1;
                        nPath++;
                    }
                }
            }
            Console.WriteLine(nPath);
        }

        private void MoveX(ref List<int> listH, ref List<int> listT)
        {
            if (listH[0] > listT[0])
            {
                listT[0]++;
                if (listH[1] < listT[1])
                {
                    listT[1]--;
                }
                else if (listH[1] > listT[1])
                {
                    listT[1]++;
                }
            }
            else if (listH[0] < listT[0])
            {
                listT[0]--;
                if (listH[1] < listT[1])
                {
                    listT[1]--;
                }
                else if (listH[1] > listT[1])
                {
                    listT[1]++;
                }

            }
        }

        private void MoveY(ref List<int> listH, ref List<int> listT)
        {
            if (listH[1] > listT[1])
            {
                listT[1]++;
                if (listH[0] < listT[0])
                {
                    listT[0]--;
                }
                else if (listH[0] > listT[0])
                {
                    listT[0]++;
                }
            }
            else if (listH[1] < listT[1])
            {
                listT[1]--;
                if (listH[0] < listT[0])
                {
                    listT[0]--;
                }
                else if (listH[0] > listT[0])
                {
                    listT[0]++;
                }

            }
        }
    }
}
