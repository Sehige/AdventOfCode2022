using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AdventOfCode
{
    internal partial class Day11
    {
        public struct Monkey
        {
            public List<float> listItems;
            public string[] sOperation;
            public int nDivider;
            public int nTrueMonkey;
            public int nFalseMonkey;

            public Monkey()
            {
                listItems = new List<float>();
                sOperation= new string[2];
                nDivider = 1;
                nTrueMonkey = 0;
                nFalseMonkey = 0;
            }
        }

        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day11\\Day11.txt");

            Dictionary<int, Monkey> keyMonkey = new Dictionary<int, Monkey>();
            List<Monkey> listMonkey = new List<Monkey>();
            Monkey buildMonkey = new Monkey();
            int nIndexMonkey = 0;

            foreach (string s in sText)
            {
                if (s.Contains("Monkey"))
                {
                    //listMonkey.Add(buildMonkey);
                    string sNumber = s.Split(' ')[1].Trim(':');
                    nIndexMonkey = int.Parse(sNumber);

                    buildMonkey = new Monkey();
                }
                else if (s.Contains("Starting"))
                {
                    string[] sStarting = s.Split(' ');
                    foreach(string sNumbers in sStarting)
                    {
                        if (float.TryParse(sNumbers.Trim(','), out float item))
                        {
                            buildMonkey.listItems.Add(item);
                        }
                    }
                }
                else if (s.Contains("Operation"))
                {
                    if (s.Contains("old + old"))
                    {
                        buildMonkey.sOperation[0] = "+";
                    }
                    else if (s.Contains("old * old"))
                    {
                        buildMonkey.sOperation[0] = "*";
                    }
                    else
                    {
                        string[] sOperation = s.Split(' ');
                        for (int i = 0; i < sOperation.Length; i++)
                        {
                            if (int.TryParse(sOperation[i], out int nNumber)) 
                            {
                                buildMonkey.sOperation[0] = nNumber.ToString();
                                buildMonkey.sOperation[1] = sOperation[i - 1];
                            }
                        }
                    }
                }
                else if (s.Contains("Test"))
                {
                    string[] sDiv = s.Split(" ");
                    foreach(string str in sDiv)
                    {
                        if (int.TryParse(str, out int nDiv))
                        {
                            buildMonkey.nDivider = nDiv;
                        }
                    }
                }
                else if (s.Contains("true"))
                {
                    string[] sTrue = s.Split(" ");
                    foreach (string str in sTrue)
                    {
                        if (int.TryParse(str, out int nTrue))
                        {
                            buildMonkey.nTrueMonkey = nTrue;
                        }
                    }
                }
                else if (s.Contains("false"))
                {
                    string[] sFalse = s.Split(" ");
                    foreach (string str in sFalse)
                    {
                        if (int.TryParse(str, out int nFalse))
                        {
                            buildMonkey.nFalseMonkey = nFalse;
                        }
                    }

                    listMonkey.Add(buildMonkey);
                }
            }
        }
    }
}
