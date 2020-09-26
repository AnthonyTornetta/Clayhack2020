using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    public class Event
    {
        private int startTime { get; set; }
        private int endTime { get; set; }
        private string name { get; set; }
        private string type { get; set; }
        private CustomTime specifiedTime;
        private CustomTime dueDate;

        public Event(int startTime, int endTime, string name, string type, CustomTime dueDate, CustomTime specifiedTime )
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.name = name;
            this.type = type;
            this.dueDate = dueDate;
        }

        public void ModifyTime(int day, Time time)
        {
            this.specifiedTime.addTimeToDay(day, time)
        }
    }
}
