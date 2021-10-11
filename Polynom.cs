using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_6
{
    class Polynom
    {
        public List<(int, double)> RankAndRealList { get; set; }

        public Polynom(List<(int, double)> rankAndRealList)
        {
            RankAndRealList = rankAndRealList;
        }

        public Polynom()
        {
            RankAndRealList = new List<(int, double)>();
        }

        public override string ToString()
        {
            string res = "";

            RankAndRealList.Sort();

            foreach (var item in RankAndRealList)
            {

                if (item.Item2 == 0)
                    RankAndRealList.Remove(item);
                else if (res == "")
                {
                    if (item.Item1 == 0 && item.Item2 > 0)
                        res += $"{item.Item2}";
                    else res += $"{item.Item2}X^{item.Item1}";
                }
                else if (item.Item1 == 0 && item.Item2 > 0)
                    res += $"+{item.Item2}";
                else if (item.Item1 == 0 && item.Item2 > 0)
                    res += $"{item.Item2}";
                else if (item.Item2 > 0)
                {
                    res += $"+{item.Item2}X^{item.Item1}";
                }
                else res += $"{item.Item2}X^{item.Item1}";
            }



            return res;
        }

        public static Polynom Parse(string data)
        {
            data = data.Replace("X^", " ");
            data = data.Replace('+', ' ');
            data = data.Replace(".", ",");
            data = data.Replace("-", " -");

            string[] dates = data.Split();

            List<(int, double)> rankAndRealList = new List<(int, double)>();

            if (dates.Length % 2 != 0)
                throw new ArgumentException();


            int index = 0;

            (int, double) temp = (0, 0);

            foreach (var item in dates)
            {
                if (index % 2 == 0)
                    temp.Item2 = double.Parse(item);

                if (index % 2 == 1)
                {
                    temp.Item1 = int.Parse(item);

                    rankAndRealList.Add(temp);
                }

                index++;
            }
            return new Polynom(rankAndRealList);
        }

        public static implicit operator Polynom(double value)
        {
            Polynom polynom = new Polynom();

            polynom[0] = value;

            return polynom;
        }

        public static Polynom operator +(Polynom first, Polynom second)
        {
            List<(int, double)> RankAndRealList = new List<(int, double)>();

            (int, double) temp = (0, 0);

            bool res = true;

            foreach (var item in first.RankAndRealList)
            {
                res = true;
                foreach (var item2 in second.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        temp.Item1 = item.Item1;

                        temp.Item2 = item.Item2 + item2.Item2;

                        RankAndRealList.Add(temp);
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            foreach (var item in second.RankAndRealList)
            {
                res = true;
                foreach (var item2 in first.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            return new Polynom(RankAndRealList);
        }

        public static Polynom operator -(Polynom first, Polynom second)
        {
            List<(int, double)> RankAndRealList = new List<(int, double)>();

            (int, double) temp = (0, 0);

            bool res = true;
            foreach (var item in first.RankAndRealList)
            {
                res = true;
                foreach (var item2 in second.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        temp.Item1 = item.Item1;

                        temp.Item2 = item.Item2 - item2.Item2;

                        RankAndRealList.Add(temp);
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            foreach (var item in second.RankAndRealList)
            {
                res = true;
                foreach (var item2 in first.RankAndRealList)
                {

                    if (item.Item1 == item2.Item1)
                    {
                        res = false;
                    }

                }
                if (res)
                {
                    RankAndRealList.Add(item);
                }
            }

            return new Polynom(RankAndRealList);
        }

        public static Polynom operator *(Polynom first, Polynom second)
        {
            Polynom resPolynom = new Polynom();

            foreach (var item in first.RankAndRealList)
            {
                
                foreach (var item2 in second.RankAndRealList)
                {

                    resPolynom[item.Item1 + item2.Item1] = item.Item2 * item2.Item2+resPolynom[item.Item1 + item2.Item1];
                }
            }
            
            return resPolynom;
        }
        public Polynom(string data)
        {

            RankAndRealList = new List<(int, double)>(Polynom.Parse(data).RankAndRealList);
        }

        public double this[int Rank]
        {
            get
            {
                foreach (var item in RankAndRealList)
                {
                    if (item.Item1 == Rank)
                    {
                        return item.Item2;
                    }
                }
                return 0;
            }
            set
            {
                int index = -1;
                for (int i = 0; i < RankAndRealList.Count; i++)
                {
                    if (RankAndRealList[i].Item1 == Rank)
                    {
                        index = i;
                        break;
                    }
                }
                (int, double) temp;
                if (value == 0 && index == -1)
                {

                }
                else if (index == -1 && value != 0)
                {
                    temp.Item1 = Rank;

                    temp.Item2 = value;

                    RankAndRealList.Add(temp);
                }
                else if (index != -1 && value == 0)
                {
                    RankAndRealList.RemoveAt(index);
                }
                else if (index != -1 && value != 0)
                {
                    RankAndRealList[index] = (Rank, value);
                }
            }
        }

        public string PrintMenu()
        {
            return "\n[1]Print Polynom 1\t[2]Print Polynom 2\n[3]Add\t\t\t[4]Subtraction\n[5]Change coefficient\t[6]Multiply\n[0] Exit\n";
        }
    }
}