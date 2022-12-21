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
            public List<BigInteger> listItems;
            public string[] sOperation;
            public BigInteger nDivider;
            public int nTrueMonkey;
            public int nFalseMonkey;
            public int nInspections;

            public Monkey()
            {
                listItems = new List<BigInteger>();
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
            BigInteger dStress = 0;
            int nMonkey = 0;
            float fInspections = 0;
            List<float> listInspections = new List<float>();
            //Dictionary<int, Monkey> keyMonkey = new Dictionary<int, Monkey>();
            List<Monkey> listMonkey = GetMonkey(sText);

            foreach (Monkey monkey in listMonkey)
            {
                listInspections.Add(0);
            }

            for (int i = 0; i < 1000; i++)
            {
                nMonkey = 0;
                foreach (Monkey monkey in listMonkey)
                {
                    if (monkey.listItems.Count == 0)
                    {
                        nMonkey++;
                        continue;
                    }

                    fInspections = monkey.listItems.Count;

                    foreach (BigInteger dItem in monkey.listItems)
                    {
                        if (monkey.sOperation[1] == "*")
                        {
                            if (monkey.sOperation[0] == monkey.sOperation[1])
                            {
                                dStress = dItem * dItem;
                            }
                            else
                            {
                                dStress = dItem * BigInteger.Parse(monkey.sOperation[0]);
                            }
                        }
                        else
                        {
                            if (monkey.sOperation[0] == monkey.sOperation[1])
                            {
                                dStress = dItem + dItem;
                            }
                            else
                            {
                                dStress = dItem + BigInteger.Parse(monkey.sOperation[0]);
                            }
                        }

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
                    }

                    listInspections[nMonkey] += fInspections;
                    if (listInspections[2] > 8)
                    {

                    }
                    monkey.listItems.Clear();
                    nMonkey++;
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
                        if (BigInteger.TryParse(sNumbers.Trim(','), out BigInteger item))
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
                        if (BigInteger.TryParse(str, out BigInteger nDiv))
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

        private void WriteProdMax2(List<float> listInspections)
        {
            float fMax1 = 0;
            float fMax2 = 0;
            foreach (float n in listInspections)
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
                foreach (float fStress in monkey.listItems)
                {
                    Console.Write(fStress + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
