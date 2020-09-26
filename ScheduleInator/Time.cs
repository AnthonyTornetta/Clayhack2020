using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    public class Time
    {
        public int Hours { get; set; }

        public int Minutes { get; set; }

        public Time()
        {
            Hours = 0;
            Minutes = 0;
        }

        public Time(int hr, int min)
        {
            Hours = hr;
            Minutes = min;

            reformat();
        }

        public void reformat()
        {
            int temp = Minutes % 60;
            Hours += (Minutes - temp) / 60;
            Minutes = temp;
            Hours %= 24;
        }

        public void addHours(int amt)
        {
            Hours += amt;
            reformat();
        }

        public void addMins(int amt)
        {
            Minutes += amt;
            reformat();
        }

        public bool isAm()
        {
            return Hours < 12;
        }

        public bool isPm()
        {
            return !isAm();
        }

        public override string ToString()
        {
            int hr = Hours % 12;
            
            if (hr == 0)
                hr = 12;

            string hrS = hr + "";
            string minS = Minutes < 10 ? "0" + Minutes : Minutes + "";

            return hrS + ":" + minS + " " + (isAm() ? "AM" : "PM");
        }
    }
}
