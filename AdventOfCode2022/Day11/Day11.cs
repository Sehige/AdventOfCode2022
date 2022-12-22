using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static AdventOfCode.Day11;

namespace AdventOfCode
{
    internal partial class Day11
    {
        public struct Monkey
        {
            public List<ulong > listItems;
            public string[] sOperation;
            public ulong  nDivider;
            public int nTrueMonkey;
            public int nFalseMonkey;
            public int nInspections;

            public Monkey()
            {
                listItems = new List<ulong >();
                sOperation= new string[2];
                nDivider = 1;
                nTrueMonkey = 0;
                nFalseMonkey = 0;
                nInspections = 0;
            }
        }

        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day11\\Day11.txt");
            ulong  dStress = 0;
            ulong dCommDiv = 1;
            List<ulong > listInspections = new List<ulong >();
            List<Monkey> listMonkey = GetMonkey(sText);

            foreach (Monkey monkey in listMonkey)
            {
                listInspections.Add(0);
                dCommDiv *= monkey.nDivider;
            }

            /// 20 for Part 1
            for (int i = 0; i < 10000; i++)
            {
                for (int nMon = 0; nMon < listMonkey.Count; nMon++)
                {
                    Monkey monkey = listMonkey[nMon];
                    if (monkey.listItems.Count == 0)
                    {
                        continue;
                    }

                    listInspections[nMon] += (ulong )monkey.listItems.Count();
                    
                    while (monkey.listItems.Count() > 0)
                    {
                        if (monkey.sOperation[1] == "*")
                        {
                            if (monkey.sOperation[0] == monkey.sOperation[1])
                            {
                                dStress = monkey.listItems[0] * monkey.listItems[0];
                            }
                            else
                            {
                                dStress = monkey.listItems[0] * ulong.Parse(monkey.sOperation[0]);
                            }
                        }
                        else
                        {
                            if (monkey.sOperation[0] == monkey.sOperation[1])
                            {
                                dStress = monkey.listItems[0] + monkey.listItems[0];
                            }
                            else
                            {
                                dStress = monkey.listItems[0] + ulong.Parse(monkey.sOperation[0]);
                            }
                        }

                        /// Part 2 must be ulong
                        dStress = dStress % dCommDiv;

                        /// Part 1 and ulong must be made in decimal
                        //dStress = Math.Floor(dStress/ 3);

                        if (dStress % monkey.nDivider == 0)
                        {
                            listMonkey[monkey.nTrueMonkey].listItems.Add(dStress);
                            //Console.WriteLine("M {2}| Stress level :{0}, to Monkey{1}", dStress, monkey.nTrueMonkey, nMonkey);
                        }
                        else
                        {
                            listMonkey[monkey.nFalseMonkey].listItems.Add(dStress);
                            //Console.WriteLine("M {2}| Stress level :{0}, to Monkey{1}", dStress, monkey.nFalseMonkey, nMonkey);
                        }

                        monkey.listItems.RemoveAt(0);
                    }

                }
            }

            WriteProdMax2(listInspections);
        }

        private List<Monkey> GetMonkey(string[] sText)
        {
            List<Monkey> listMonkey = new List<Monkey>();

            Monkey buildMonkey = new Monkey();

            foreach (string s in sText)
            {
                if (s.Contains("Monkey"))
                {
                    //listMonkey.Add(buildMonkey);
                    string sNumber = s.Split(' ')[1].Trim(':');

                    buildMonkey = new Monkey();
                }
                else if (s.Contains("Starting"))
                {
                    string[] sStarting = s.Split(' ');
                    foreach (string sNumbers in sStarting)
                    {
                        if (ulong .TryParse(sNumbers.Trim(','), out ulong  item))
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
                        buildMonkey.sOperation[1] = "+";
                    }
                    else if (s.Contains("old * old"))
                    {
                        buildMonkey.sOperation[0] = "*";
                        buildMonkey.sOperation[1] = "*";
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
                    foreach (string str in sDiv)
                    {
                        if (ulong .TryParse(str, out ulong  nDiv))
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

            return listMonkey;
        }

        private void WriteProdMax2(List<ulong > listInspections)
        {
            ulong  fMax1 = 0;
            ulong  fMax2 = 0;
            foreach (ulong  n in listInspections)
            {
                if (fMax1 < n)
                {
                    fMax2 = fMax1;
                    fMax1 = n;
                }
                else if (fMax2 < n)
                {
                    fMax2 = n;
                }
            }
            Console.WriteLine(fMax1+ " " + fMax2);
            Console.WriteLine(fMax1 * fMax2);
        }

        private void WriteFinalStress(List<Monkey> listMonkey)
        {
            foreach (Monkey monkey in listMonkey)
            {
                foreach (ulong  fStress in monkey.listItems)
                {
                    Console.Write(fStress + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
