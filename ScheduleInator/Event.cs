using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    public class Event
    {
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public CustomTime specifiedTime;
        public CustomTime dueDate;

        public Event(Time startTime, Time endTime, string name, string type, CustomTime dueDate, CustomTime specifiedTime )
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Name = name;
            this.Type = type;
            this.dueDate = dueDate;
        }

        public void ModifyTime(int day, Time time)
        {
            this.specifiedTime.addTimeToDay(day, time);
        }
    }
}
