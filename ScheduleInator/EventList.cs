using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleInator
{
    class EventList
    {
        public List<Event> events;

        public EventList(List<Event> e)
        {
            events = e;
        }

        public void OrderEvents()
        {
            bool SwapEvent = false;
            for (int i = 0; i < events.Count; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    if (events[j - 1].StartTime.Hours > events[j].StartTime.Hours)
                        SwapEvent = true;
                    else if ((events[j - 1].StartTime.Hours == events[j].StartTime.Hours) && (events[j - 1].StartTime.Hours > events[j].StartTime.Hours))
                        SwapEvent = true;

                    if (SwapEvent)
                    {
                        Event temp = events[j - 1];
                        events[j - 1] = events[j];
                        events[j] = temp;
                    }
                }
            }
        }
    }
}
