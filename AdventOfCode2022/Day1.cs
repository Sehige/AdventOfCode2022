using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day1
    {
        public void Run()
        {
            string[] sText = File.ReadAllLines("C:\\Users\\SergiuAtAmbo\\source\\repos\\AdventOfCode2022\\AdventOfCode2022\\Data\\Day1.txt");
            List<double> elfCalories= new List<double>();
            double dCalories = 0d;
            double dCaloriesMax1 = 0d;
            double dCaloriesMax2 = 0d;
            double dCaloriesMax3 = 0d;

            int nIndex1 = 0;
            int nIndex2 = 0;
            int nIndex3 = 0;

            foreach (string s in sText)
            {
                double dCurr = 0d;
                double.TryParse(s, out dCurr);
                dCalories += dCurr;
                if (s == "" || s == sText[sText.Length - 1])
                {
                    elfCalories.Add(dCalories);
                    if (dCalories > dCaloriesMax1)
                    {
                        dCaloriesMax3 = dCaloriesMax2;
                        dCaloriesMax2 = dCaloriesMax1;

                        nIndex3 = nIndex2;
                        nIndex2 = nIndex1;

                        dCaloriesMax1 = dCalories;
                        nIndex1 = elfCalories.Count;
                    }

                    if (dCalories > dCaloriesMax2 && dCalories < dCaloriesMax1)
                    {
                        dCaloriesMax3 = dCaloriesMax2;
                        dCaloriesMax2 = dCalories;

                        nIndex3 = nIndex2;
                        nIndex2 = elfCalories.Count; 
                    }

                    if (dCalories > dCaloriesMax3 && dCalories < dCaloriesMax2)
                    {
                        dCaloriesMax3 = dCalories;
                        nIndex3 = elfCalories.Count;
                    }

                    dCalories = 0d;
                }
            }

            Console.WriteLine("Nr of calories {0} on elf {1}", dCaloriesMax1 + dCaloriesMax2 + dCaloriesMax3, nIndex1);
        }
    }
}
