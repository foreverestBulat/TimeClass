using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TimeClass
{
    public class Time
    {
        private int hour;
        private int minute;
        private int second;
        //private int onlySecond;

        private int Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        private int Minute
        {
            get { return minute; }
            set { minute = value; }
        }

        private int Second
        {
            get { return second; }
            set { second = value; }
        }

        public Time(int hour, int minute, int second)
        {
            int[] time = CellConvertGettingTime(hour, minute, second);

            Hour = time[0];
            Minute = time[1];
            Second = time[2];
        }

        public Time(int hour, int minute)
        {
            int[] time = CellConvertGettingTime(hour, minute, 0);

            Hour = time[0];
            Minute = time[1];
            Second = time[2];
        }

        public Time(int second)
        {
            int[] time = CellConvertGettingTime(0, 0, second);

            Hour = time[0];
            Minute = time[1];
            Second = time[2];
        }

        public int[] CellConvertGettingTime(int h, int m, int s)
        {
            int[] time = new int[3] { h, m, s };
            ConvertGettingTime(time);
            return time;
        }

        static void ConvertGettingTime(int[] time)
        {
            if (time[2] > 59)
            {
                time[1] += time[2] / 60;
                time[2] = time[2] % 60;
            }

            if (time[1] > 59)
            {
                time[0] += time[1] / 60;
                time[1] = time[1] % 60;
            }

            if (time[0] > 23)
            {
                time[0] = time[0] % 24;
            }
        }

        public override string ToString()
        {
            return String.Format("{00:00} | {01:00} | {02:00}", this.hour, this.minute, this.second);
        }

        public static Time operator + (Time t1, Time t2)
        {
            return new Time(t1.hour + t2.hour, t1.minute + t2.minute, t1.second + t2.second);
        }

        public static Time operator - (Time t1, Time t2)
        {
            if (t1 < t2) throw new ArgumentException("Нельзя вычитать большее время из меньшего");
            return new Time(t1.hour - t2.hour, t1.minute - t2.minute, t1.second - t2.second);
        }

        public static Time operator * (Time t1, int a)
        {
            return new Time(0, 0, (t1.hour * 60 + t1.minute * 60 + t1.second) * a);
        }

        public static Time operator / (Time t1, int a)
        {
            return new Time(0, 0, (t1.hour * 60 + t1.minute * 60 + t1.second) / a);
        }

        public static bool operator > (Time t1, Time t2)
        {
            return (t1.hour * 60 + t1.minute * 60 + t1.second) > (t2.hour * 60 + t2.minute * 60 + t2.second);
        }

        public static bool operator <= (Time t1, Time t2)
        {
            return !(t1 > t2);
        }

        public static bool operator < (Time t1, Time t2)
        {
            return (t1.hour * 60 + t1.minute * 60 + t1.second) < (t2.hour * 60 + t2.minute * 60 + t2.second);
        }

        public static bool operator >= (Time t1, Time t2)
        {
            return !(t1 < t2);
        }
    }
}