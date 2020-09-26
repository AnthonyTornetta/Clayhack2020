using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    /// <summary>
    /// Represents a collection of times that can occur during a week
    /// </summary>
    public class CustomTime
    {
        Time time { get; set; }
        bool[] days;
        bool FixedTime { get; set; }

        public bool this[int i]
        {
            get { return days[i]; }
            set { days[i] = value; }
        }

        public CustomTime()
        {
            time = new Time();
            days = new bool[7];
        }

        public CustomTime(Time time, bool[] days, bool fixedTime)
        {
            if (days.Length != 7)
                throw new Exception("Length of times must be 7!");

            this.days = days;
            this.time = time;
            this.FixedTime = fixedTime;
        }
    }
}
