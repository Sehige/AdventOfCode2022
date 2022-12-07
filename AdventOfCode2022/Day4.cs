using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4
    {
        public void Run()
        {
            string[] sText = File.ReadAllLines("C:\\Users\\SergiuAtAmbo\\source\\repos\\AdventOfCode2022\\AdventOfCode2022\\Data\\Day4.txt");
            int nOverlap = 0;

            foreach(string s in sText)
            {
                nOverlap += Part2(s);
            }

            Console.WriteLine(nOverlap);
        }

        private int Part1(string s)
        {
            int nOverlap = 0;

            string sFirstWorker = s.Split(',')[0];
            int nFirstMin = int.Parse(sFirstWorker.Split('-')[0]);
            int nFirstMax = int.Parse(sFirstWorker.Split('-')[1]);

            string sSecondWorker = s.Split(',')[1];
            int nSecondMin = int.Parse(sSecondWorker.Split('-')[0]);
            int nSecondMax = int.Parse(sSecondWorker.Split('-')[1]);

            if (nFirstMin >= nSecondMin && nFirstMax <= nSecondMax)
            {
                nOverlap++;
            }
            else if (nFirstMin <= nSecondMin && nFirstMax >= nSecondMax)
            {
                nOverlap++;
            }

            return nOverlap;
        }

        private int Part2(string s)
        {
            int nOverlap = 0;

            string sFirstWorker = s.Split(',')[0];
            int nFirstMin = int.Parse(sFirstWorker.Split('-')[0]);
            int nFirstMax = int.Parse(sFirstWorker.Split('-')[1]);

            string sSecondWorker = s.Split(',')[1];
            int nSecondMin = int.Parse(sSecondWorker.Split('-')[0]);
            int nSecondMax = int.Parse(sSecondWorker.Split('-')[1]);

            if (nFirstMin <= nSecondMin && nSecondMin <= nFirstMax)
            {
                nOverlap++;
            }
            else if (nFirstMin <= nSecondMax && nSecondMax <= nFirstMax)
            {
                nOverlap++;
            }
            else if (nSecondMin <= nFirstMin && nFirstMin <= nSecondMax)
            {
                nOverlap++;
            }
            else if (nSecondMin <= nFirstMax && nFirstMax <= nSecondMax) 
            {
                nOverlap++;
            }

            return nOverlap;
        }
    }
}
