using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    class Event
    {
        private int startTime { get; set; }
        private int endTime { get; set; }
        private string name { get; set; }
        private string type { get; set; }
        private int dueDate { get; set; }

        public Event(int startTime, int endTime, string name, string type, int dueDate, CustomTime customTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.name = name;
            this.type = type;
            this.dueDate = dueDate;
        }
    }
}
