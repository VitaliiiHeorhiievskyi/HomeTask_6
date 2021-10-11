using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_6
{
    class SiteTrafficStatistics
    {
        public List<Visitor> Visitors { get; set; }

        public SiteTrafficStatistics()
        {
            Visitors = new List<Visitor>();
        }

        public void ReadDataFromFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            string[] lines = reader.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                AddVisitor(line);
            }

            reader.Close();
        }

        public void AddVisitor(string line)
        {
            if (string.IsNullOrEmpty(line))
                throw new ArgumentNullException();

            string[] data = line.Trim('\r').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length != 3)
                throw new ArgumentException("Data is incorrect!!");

            if (!CheckIp(data[0]))
                throw new ArgumentException();

            string ip = data[0];

            bool result = DateTime.TryParseExact(data[1], "HH:mm:ss", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out DateTime time);

            if (!result)
                throw new ArgumentException("Date is not correct!");

            DayOfWeek day;

            switch (data[2])
            {
                case "Monday":
                    day = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    day = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    day = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    day = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    day = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    day = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    day = DayOfWeek.Sunday;
                    break;
                default: throw new ArgumentException("Category is not correct");
            }

            Visitors.Add(new Visitor(ip, time, day));
        }

        public int GetCountOfVisit(string ip)
        {
            if (!CheckIp(ip))
                throw new ArgumentException();

            return Visitors.Where(i => i.Ip == ip).ToList().Count;
        }

        public DayOfWeek GetTheMostPopularDay(string ip)
        {
            if (!CheckIp(ip))
                throw new ArgumentException();

            DayOfWeek popularDay = DayOfWeek.Friday;

            int count = 0;

            List<Visitor> thisVisitor = Visitors.Where(i => i.Ip == ip).ToList();

            for (int i = 0; i < 7; i++)
            {
                if (thisVisitor.Where(j => ((int)j.Day == i + 1)).ToList().Count > count)
                {
                    popularDay = (DayOfWeek)(i + 1);
                    count = thisVisitor.Where(j => ((int)j.Day == i + 1)).ToList().Count;
                }
            }

            return popularDay;
        }

        public int GetTheMostPopularHourForVisitor(string ip)
        {
            if (!CheckIp(ip))
                throw new ArgumentException();

            int count = 0;

            int hour = 0;
            List<Visitor> thisSite = Visitors.Where(i => i.Ip == ip).ToList();

            for (int i = 0; i < 24; i++)
            {
                if (thisSite.Where(j => (j.Time.Hour == i)).ToList().Count > count)
                {
                    hour = i;
                    count = thisSite.Where(j => (j.Time.Hour == i)).ToList().Count;
                }
            }

            return hour;
        }

        public int GetTheMostPopularHourForSite()
        {
            int count = 0;

            int hour = -1;

            for (int i = 0; i < 24; i++)
            {
                if (Visitors.Where(j => (j.Time.Hour == i)).ToList().Count > count)
                {
                    hour = i;
                    count = Visitors.Where(j => (j.Time.Hour == i)).ToList().Count;
                }
            }

            return hour;
        }

        public static bool CheckIp(string ip)
        {
            if (ip == null)
                return false;

            if (ip.Split(".").Length != 4)
                return false;

            int tempNumber;
            for (int i = 0; i < 4; i++)
            {
                if (!int.TryParse(ip.Split(".")[i], out tempNumber))
                    return false;

                if (tempNumber > 255 || tempNumber < 0)
                    return false;
            }

            return true;

        }

        public override string ToString()
        {
            string res = "";

            foreach (var visitor in Visitors)
            {
                res += visitor.ToString();
            }
            return res;
        }
    }
}
