using System.ComponentModel;
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
            // Step 1:
            // Put in pre-determined times by user
            // Step 2:
            // Sort non predetermined events by their due date
            // Put them in based off where they fit in order of their due date
            // Step 3:
            // Autofill the rest

            bool SwapEvent = false;
            for (int i = 0; i < events.Count; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    if (!(events[j - 1].SpecifiedTime.StartTime.isAm() == events[j].SpecifiedTime.StartTime.isPm()))
                    {
                        if (events[j - 1].SpecifiedTime.StartTime.Hours > events[j].SpecifiedTime.StartTime.Hours)
                            SwapEvent = true;
                        else if ((events[j - 1].SpecifiedTime.StartTime.Hours == events[j].SpecifiedTime.StartTime.Hours) && (events[j - 1].SpecifiedTime.StartTime.Minutes > events[j].SpecifiedTime.StartTime.Minutes))
                            SwapEvent = true;
                    }

                    if (SwapEvent)
                    {
                        Event temp = events[j - 1];
                        events[j - 1] = events[j];
                        events[j] = temp;
                    }
                }
            }
        }

        public void addEvent(Event e)
        {
            events.Add(e);
        }

        public void removeEvent(Event e)
        {
            events.Remove(e);
        }
    }
}
