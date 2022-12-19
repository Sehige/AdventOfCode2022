using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2022
{
    internal class Day3
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day3\\Day3.txt");

            List<char> listBad = new List<char>();
            int nSum = 0;

            nSum = Part2(sText);

            Console.WriteLine(nSum);
        }

        private int Part1(string[] sText)
        {
            int nSum = 0;

            foreach (string s in sText)
            {
                string sFirst = s.Substring(0, s.Length / 2);
                string sSecond = s.Substring(s.Length / 2);
                Dictionary<char, int> keyBackpack = new Dictionary<char, int>();

                foreach (char cElement in sFirst)
                {
                    bool bExist = keyBackpack.TryGetValue(cElement, out int value);
                    if (bExist == false)
                    {
                        keyBackpack.Add(cElement, 0);
                    }
                }

                foreach (char cElement in sSecond)
                {
                    bool bExist = keyBackpack.TryGetValue(cElement, out int value);
                    if (bExist && keyBackpack[cElement] == 0)
                    {
                        keyBackpack[cElement]++;
                        if (Char.IsUpper(cElement))
                            nSum += (int)(cElement) - 64 + 26;
                        else
                            nSum += (int)(cElement) - 96;
                    }
                }
            }

            return nSum;
        }

        private int Part2(string[] sText)
        {
            int nSum = 0;
            Dictionary<char, int> keyBadge = new Dictionary<char, int>();

            for (int i = 0; i < sText.Length; i++)
            {
                string s = sText[i];
                string sFirst = s.Substring(0, s.Length / 2);
                string sSecond = s.Substring(s.Length / 2);
                Dictionary<char, bool> keyBackpack = new Dictionary<char, bool>();
                if (i % 3 == 0)
                {
                    foreach (char cKey in keyBadge.Keys)
                    {
                        if (keyBadge[cKey] == 3)
                        {
                            if (Char.IsUpper(cKey))
                                nSum += (int)(cKey) - 64 + 26;
                            else
                                nSum += (int)(cKey) - 96;
                        }
                    }
                    keyBadge.Clear();
                }

                foreach (char cElement in s)
                {
                    bool bExist = keyBackpack.TryGetValue(cElement, out bool value);
                    if (bExist == false)
                    {
                        keyBackpack.Add(cElement, value);
                        if (keyBadge.TryGetValue(cElement, out int value1) == false)
                        {
                            keyBadge.Add(cElement, 1);
                        }
                        else
                        {
                            keyBadge[cElement]++;
                        }
                    }
                }
            }

            foreach (char cKey in keyBadge.Keys)
            {
                if (keyBadge[cKey] == 3)
                {
                    if (Char.IsUpper(cKey))
                        nSum += (int)(cKey) - 64 + 26;
                    else
                        nSum += (int)(cKey) - 96;
                }
            }

            return nSum;
        }
    }
}
