using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    public class Event
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public CustomTime SpecifiedTime { get; set; }
        public CustomTime dueDate;

        public Event(string name, string type, CustomTime dueDate, CustomTime specifiedTime )
        {
            this.SpecifiedTime = specifiedTime;
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
