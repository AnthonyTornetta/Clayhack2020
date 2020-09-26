using System.Collections.Generic;
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

        public EventList(List<Event> ev)
        {
            events = ev;
        }

        public void AddSpecializedEvent(Event e)
        {
            if (e.SpecifiedTime.FixedTime)
            {
                events.Add(e);
            }
            else if (e.dueDate != null)
            {
                events.Add(e);
            }
        }

        public void SortPreDeterminedAndDueDated()
        {
            List<Event> preDetermined = new List<Event>();
            List<Event> dueDated = new List<Event>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].SpecifiedTime.FixedTime)
                    preDetermined.Add(events[i]);
                else
                    dueDated.Add(events[i]);
            }

            events.Clear();
            events.TrimExcess();
            events.InsertRange(0, preDetermined);
            events.InsertRange(events.Count, dueDated);
        }

        // Step 1:
        // Put in pre-determined times by user
        // Step 2:
        // Sort non predetermined events by their due date
        // Put them in based off where they fit in order of their due date
        // Step 3:
        // Autofill the rest

            
    }
}
