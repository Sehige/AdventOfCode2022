using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day8
    {
        public void Run()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + "\\day8\\Day8.txt");

            int[][] arrayTree = new int[sText.Length][];

            for (int nIndex = 0; nIndex < sText.Length; nIndex++)
            {
                string s = sText[nIndex];
                arrayTree[nIndex] = new int[s.Length];

                for(int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    arrayTree[nIndex][i] = (int)Char.GetNumericValue(c);
                }
            }

            int nVisibleTree = arrayTree.Length * 2 + arrayTree[0].Length * 2 - 4;
            int nMaxView = 1;

            for(int nIndexTree = 1; nIndexTree < arrayTree.Length - 1; nIndexTree++)
            {
                int[] arrayIntern = arrayTree[nIndexTree];

                for (int nIntern = 1; nIntern < arrayIntern.Length - 1; nIntern++)
                {
                    ///Part1
                    //if (VisibleRight1(arrayIntern, nIntern)) nVisibleTree++;
                    //else if (VisibleLeft1(arrayIntern, nIntern)) nVisibleTree++;
                    //else if (VisibleTop1(arrayTree, nIndexTree, nIntern)) nVisibleTree++;
                    //else if (VisibleBottom1(arrayTree, nIndexTree, nIntern)) nVisibleTree++;

                    ///Part2
                    int nViewScore = 1;
                    nViewScore *= VisibleRight2(arrayIntern, nIntern);
                    nViewScore *= VisibleLeft2(arrayIntern, nIntern);
                    nViewScore *= VisibleTop2(arrayTree, nIndexTree, nIntern);
                    nViewScore *= VisibleBottom2(arrayTree, nIndexTree, nIntern);

                    if (nMaxView < nViewScore) 
                        nMaxView = nViewScore;
                }

            }

            Console.WriteLine(nMaxView);
        }

        #region Part1

        private bool VisibleTop1(int[][] arrayTree, int nTreeX, int nTreeY)
        {
            bool bVisible = true;
            int[] arrayIntern = arrayTree[nTreeX];
            int nTree = arrayIntern[nTreeY];

            for (int i = nTreeX; i > 0; i--)
            {
                int[] arrayAbove = arrayTree[i - 1];
                int nTreeAbove = arrayAbove[nTreeY];
                if (nTree <= nTreeAbove)
                {
                    bVisible = false;
                    break;
                }
            }

            return bVisible;
        }

        private bool VisibleBottom1(int[][] arrayTree, int nTreeX, int nTreeY)
        {
            bool bVisible = true;
            int[] arrayIntern = arrayTree[nTreeX];
            int nTree = arrayIntern[nTreeY];

            for (int i = nTreeX + 1; i < arrayIntern.Length; i++)
            {
                int[] arrayBelow = arrayTree[i];
                int nTreeBelow = arrayBelow[nTreeY];
                if (nTree <= nTreeBelow)
                {
                    bVisible = false;
                    break;
                }
            }

            return bVisible;
        }

        private bool VisibleRight1(int[] arrayIntern, int nIntern)
        {
            bool bVisible = true;

            for (int i = nIntern + 1; i < arrayIntern.Length; i++)
            {
                if (arrayIntern[nIntern] <= arrayIntern[i])
                {
                    bVisible = false;
                    break;
                }
            }

            return bVisible;
        }

        private bool VisibleLeft1(int[] arrayIntern, int nIntern)
        {
            bool bVisible = true;

            for (int i = nIntern - 1; i >= 0; i--)
            {
                if (arrayIntern[nIntern] <= arrayIntern[i])
                {
                    bVisible = false;
                    break;
                }
            }

            return bVisible;
        }
        #endregion

        #region Part2

        private int  VisibleTop2(int[][] arrayTree, int nTreeX, int nTreeY)
        {
            int nVisible = 0;
            int[] arrayIntern = arrayTree[nTreeX];
            int nTree = arrayIntern[nTreeY];

            for (int i = nTreeX; i > 0; i--)
            {
                nVisible++;
                int[] arrayAbove = arrayTree[i - 1];
                int nTreeAbove = arrayAbove[nTreeY];
                if (nTree <= nTreeAbove)
                {
                    break;
                }
            }

            return nVisible;
        }

        private int VisibleBottom2(int[][] arrayTree, int nTreeX, int nTreeY)
        {
            int nVisible = 0;
            int[] arrayIntern = arrayTree[nTreeX];
            int nTree = arrayIntern[nTreeY];

            for (int i = nTreeX + 1; i < arrayIntern.Length; i++)
            {
                nVisible++;
                int[] arrayBelow = arrayTree[i];
                int nTreeBelow = arrayBelow[nTreeY];
                if (nTree <= nTreeBelow)
                {
                    break;
                }
            }

            return nVisible;
        }

        private int VisibleRight2(int[] arrayIntern, int nIntern)
        {
            int nVisible = 0;

            for (int i = nIntern + 1; i < arrayIntern.Length; i++)
            {
                nVisible++;
                if (arrayIntern[nIntern] <= arrayIntern[i])
                {
                    break;
                }

            }

            return nVisible;
        }

        private int VisibleLeft2(int[] arrayIntern, int nIntern)
        {
            int nVisible = 0;

            for (int i = nIntern - 1; i >= 0; i--)
            {
                nVisible++;
                if (arrayIntern[nIntern] <= arrayIntern[i])
                {
                    break;
                }
            }

            return nVisible;
        }

        #endregion
    }
}
