using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day7
    {
        public struct Key
        {
            public string sDir;
            public int nLevel;
            public string sParentDir;

            public Key(string sDir, int nLevel, string sParentDir)
            {
                this.sDir = sDir;
                this.nLevel = nLevel;
                this.sParentDir = sParentDir;
            }
        }

        public struct TreeData
        {
            public int nLevel;
            public string sName;
            public decimal dSize;
            public string sParentDir;

            public TreeData(int nLevel, string sName, decimal dSize, string sParentDir)
            {
                this.nLevel = nLevel;
                this.sName = sName;
                this.dSize = dSize;
                this.sParentDir = sParentDir;
            }
        }

        public struct Dir
        {
            public List<Dir> listFiles;
            public string sName;
            public decimal dSize;

            public Dir(List<Dir> listFiles, string sName, decimal dSize)
            {
                this.listFiles = listFiles;
                this.sName = sName;
                this.dSize = dSize;
            }
        }

        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day7\\Day7.txt");

            int nCurrLevel = 0;
            string sParentDir = "/";
            string sCurrDir = "";

            List<TreeData> treeView = new List<TreeData>();
            treeView.Add(new TreeData(0, "/", 0, ""));
            Dictionary<Key, decimal> keyValuePairs = new Dictionary<Key, decimal>();
            keyValuePairs.Add(new("/", 0, "/"), 0);
            bool bLs = false;
            foreach (string s in sText)
            {
                string[] sData = s.Split(" ");
                if (sData[0] == "$") bLs = false;

                if (bLs)
                {
                    if (sData[0] == "dir")
                    {
                        //sCurrDir = sData[1];
                        treeView.Add(new TreeData(nCurrLevel, sData[1], 0, sParentDir));
                        if (keyValuePairs.TryGetValue(new(sData[1], nCurrLevel, sParentDir), out decimal value) == false)
                            keyValuePairs.Add(new(sData[1], nCurrLevel, sParentDir), 0);
                        else
                        {

                        }
                    }
                    else
                    {
                        Decimal.TryParse(sData[0], out decimal dSize);
                        treeView.Add(new TreeData(nCurrLevel, sData[1], dSize, sParentDir));
                        //keyValuePairs[new (sParentDir, nCurrLevel - 1, sParentDir)] += dSize;
                    }
                }
                else if (sData[0] == "$")
                {
                    if (sData[1] == "cd")
                    {
                        if (sData[2] == "/")
                        {
                            nCurrLevel = 1;
                        }
                        else if (sData[2] == "..")
                        {
                            nCurrLevel--;
                        }
                        else
                        {
                            sParentDir = sData[2];
                            nCurrLevel++;
                        }
                    }
                    else if (sData[1] == "ls")
                    {
                        bLs = true;
                    }
                }

            }

            treeView.Sort((x,y) => y.nLevel.CompareTo(x.nLevel));

            foreach (TreeData Data in treeView)
            {
                if (Data.dSize == 0 && Data.sParentDir != "")
                {
                    keyValuePairs[new(Data.sParentDir, Data.nLevel - 1, Data.sParentDir)] += keyValuePairs[new(Data.sName, Data.nLevel, Data.sParentDir)];
                }
            }

            decimal dTotal = 0;
            foreach (Key sKey in keyValuePairs.Keys)
            {
                if (keyValuePairs[sKey] <= 100000)
                {
                    dTotal += keyValuePairs[sKey];
                }
            }
            Console.WriteLine(dTotal);
        }

       /* public void Run2()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\Data\\Day7.txt");

            List<Dir> listTree = new List<Dir>();
            List<Dir> listCurr = new List<Dir>();
            foreach (string s in sText)
            {
                string[] sData = s.Split(" ");

                
                 if (sData[0] == "$")
                {
                    if (sData[1] == "cd")
                    {
                        if (sData[2] == "/")
                        {
                            nCurrLevel = 1;
                        }
                        else if (sData[2] == "..")
                        {
                            nCurrLevel--;
                        }
                        else
                        {
                            sParentDir = sData[2];
                            nCurrLevel++;
                        }
                    }
                    else if (sData[1] == "ls")
                    {
                        bLs = true;
                    }
                }
                else if (sData[0] == "dir")
                {
                    //sCurrDir = sData[1];
                    treeView.Add(new TreeData(nCurrLevel, sData[1], 0, sParentDir));
                    if (keyValuePairs.TryGetValue(new(sData[1], nCurrLevel, sParentDir), out decimal value) == false)
                        keyValuePairs.Add(new(sData[1], nCurrLevel, sParentDir), 0);
                    else
                    {

                    }
                }
                else
                {
                    Decimal.TryParse(sData[0], out decimal dSize);
                    treeView.Add(new TreeData(nCurrLevel, sData[1], dSize, sParentDir));
                    //keyValuePairs[new (sParentDir, nCurrLevel - 1, sParentDir)] += dSize;
                }

            }
        }*/
    }
}
