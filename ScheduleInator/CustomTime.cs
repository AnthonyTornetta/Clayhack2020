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
    [Serializable]
    public class CustomTime
    {
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }

        public bool[] days;
        public bool FixedTime { get; set; }

        public Time eta { get; set; }

        public bool this[int i]
        {
            get { return days[i]; }
            set { days[i] = value; }
        }

        public CustomTime()
        {
            StartTime = new Time();
            EndTime = new Time();
            days = new bool[7];
        }

        public CustomTime(Time startTime, Time endTime, bool[] days, bool fixedTime)
        {
            if (days.Length != 7)
                throw new Exception("Length of times must be 7!");

            this.days = days;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.FixedTime = fixedTime;
        }

        public CustomTime(bool[] days, bool fixedTime, Time eta)
        {
            if (days.Length != 7)
                throw new Exception("Length of times must be 7!");

            this.days = days;
            this.StartTime = null;
            this.EndTime = null;
            this.FixedTime = fixedTime;
            this.eta = eta;
        }
    }
}
