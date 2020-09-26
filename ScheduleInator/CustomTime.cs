using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    /// <summary>
    /// Represents a collection of times that can occur during a week
    /// </summary>
    public class CustomTime
    {
        List<Time>[] times;

        public CustomTime()
        {
            times = new List<Time>[7];
        }

        /// <summary>
        /// Gets the times for a given day
        /// </summary>
        /// <param name="day">0-7 = sunday-saturday</param>
        /// <returns></returns>
        public List<Time> getTimesForDay(int day)
        {
            return times[day];
        }

        public void addTimeToDay(int day, Time time)
        {
            times[day].Add(time);
        }
    }
}
