using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day5\\Day5.txt");
            List<Stack<char>> ListStack = new List<Stack<char>>();
            for (int i = 0; i < 9; i++)
            {
                ListStack.Add(new Stack<char>());
            }
            bool bBreak = false;
            int nCrates = 0;
            for (nCrates = 0; nCrates < sText.Length; nCrates++)
            {
                if (bBreak) break;

                string s = sText[nCrates];
                int nIndex = 0;
                int nBlanks = 0;
                foreach (char c in s)
                {
                    if (c == ' ')
                    {
                        nBlanks++;
                        if (nBlanks == 4)
                        {
                            nIndex++;
                            nBlanks = 0;
                        }
                    }
                    else if (c == '[' || c == ']') continue;
                    else if (Char.IsLetter(c))
                    {
                        if (nBlanks == 1 || nBlanks == 5)
                            nIndex++;
                        nBlanks = 0;
                        ListStack[nIndex].Push(c);
                    }
                    else
                    {
                        bBreak = true;
                        break;
                    }
                }
            }

            ListStack = ReturnListReversed(ListStack);

            nCrates += 1;

            List<int> list = new List<int>();

            for (; nCrates < sText.Length; nCrates++)
            {
                list.Clear();
                string s = sText[nCrates];
                foreach (string sSplit in s.Split(" "))
                {
                    if (int.TryParse(sSplit, out int nMove))
                    {
                        list.Add(nMove);
                    }
                }

                /// Part 2
                Stack<char> stackPart2 = new Stack<char>();

                for (int i = 0; i < list[0]; i++)
                {
                    if (ListStack[list[1] - 1].Count > 0)
                    {
                        char cBoxMove = ListStack[list[1] - 1].Pop();
                        /// Part2
                        stackPart2.Push(cBoxMove);

                        ///Part1
                        ///ListStack[list[2] - 1].Push(cBoxMove);
                    }
                }

                /// Part 2
                while (stackPart2.Count > 0)
                {
                    ListStack[list[2] - 1].Push(stackPart2.Pop());
                }
            }

            foreach (Stack<char> listStack in ListStack)
            {
                if (listStack.Count > 0)
                {
                    Console.Write(listStack.Pop());
                }
            }
        }

        private List<Stack<char>> ReturnListReversed (List<Stack<char>> list)
        {
            List<Stack<char>> ListStackReverse = new List<Stack<char>>();

            for(int i = 0; i < 9; i++)
            {
                ListStackReverse.Add(new Stack<char>());
            }

            for (int nIndex = 0; nIndex < list.Count; nIndex++)
            {
                Stack<char> c = list[nIndex];
                while (c.Count > 0)
                {
                    char cReverse = c.Pop();
                    ListStackReverse[nIndex].Push(cReverse);
                }
            }

            return ListStackReverse;
        }
    }
}
