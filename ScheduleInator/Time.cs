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

        public void addHours(int amt)
        {
            Hours += amt;
            Hours %= amt;
        }

        public void addMins(int amt)
        {
            Minutes += amt;
            int temp = Minutes % 60;
            Hours += (Minutes - temp) / 60;
            Minutes = temp;
        }

        public bool isAm()
        {
            return Hours < 12;
        }

        public bool isPm()
        {
            return !isAm();
        }
    }
}
