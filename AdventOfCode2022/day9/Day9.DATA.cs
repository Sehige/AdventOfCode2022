using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public partial class Day9
    {
        public Dictionary<int, List<int>> keyData = new Dictionary<int, List<int>>();
        public int[,] arrayPath = new int[601, 601];

        public List<int> listH = new List<int>();

        public List<int> list1 = new List<int>();

        public List<int> list2 = new List<int>();

        public List<int> list3 = new List<int>();

        public List<int> list4 = new List<int>();

        public List<int> list5 = new List<int>();

        public List<int> list6 = new List<int>();

        public List<int> list7 = new List<int>();

        public List<int> list8 = new List<int>();

        public List<int> list9 = new List<int>();

        public List<int> listPrevH = new List<int>();

        public void SetData()
        {
            arrayPath[300, 300] = 1;

            listH.Add(300);
            listH.Add(300);

            list1.Add(300);
            list1.Add(300);

            list2.Add(300);
            list2.Add(300);

            list3.Add(300);
            list3.Add(300);

            list4.Add(300);
            list4.Add(300);

            list5.Add(300);
            list5.Add(300);

            list6.Add(300);
            list6.Add(300);

            list7.Add(300);
            list7.Add(300);

            list8.Add(300);
            list8.Add(300);

            list9.Add(300);
            list9.Add(300);

            keyData.Add(0, listH); 
            keyData.Add(1, list1);
            keyData.Add(2, list2);
            keyData.Add(3, list3);
            keyData.Add(4, list4);
            keyData.Add(5, list5);
            keyData.Add(6, list6);
            keyData.Add(7, list7);
            keyData.Add(8, list8);
            keyData.Add(9, list9);
        }
    }
}
