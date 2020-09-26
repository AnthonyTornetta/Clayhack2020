using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    class Time
    {
        private int hour, min;

        public void addHours(int amt)
        {
            hour += amt;
            hour %= amt;
        }

        public void addMins(int amt)
        {
            min += amt;
            int temp = min % 60;
            hour += (min - temp) / 60;
            min = temp;
        }

        public bool isAm()
        {
            return hour < 12;
        }

        public bool isPm()
        {
            return !isAm();
        }

        public int getHours()
        {
            return hour;
        }

        public int getMinutes()
        {
            return min;
        }

        public void setHours(int hours)
        {
            this.hour = hours;
        }

        public void setMinutes(int m)
        {
            this.min = m;
        }
    }
}
