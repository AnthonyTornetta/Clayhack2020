using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    public class Event
    {
        public CustomTime StartTime { get; set; }
        public CustomTime EndTime { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        private CustomTime specifiedTime;
        private CustomTime dueDate;

        public Event(CustomTime startTime, CustomTime endTime, string name, string type, CustomTime dueDate, CustomTime specifiedTime )
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
