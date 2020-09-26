using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleInator
{
    class EventList
    {
        public List<Event> events;


        public EventList(List<Event> ev)
        {
            events = ev;
        }

        public void Add(Event e)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].SpecifiedTime != null)
                    AddPreDeterminedEvent(e, i);
                else if (e.dueDate != null)
                    AddDueDated(e);
                else if (e.SpecifiedTime.StartTime == null && e.SpecifiedTime.EndTime == null)
                    AddETATimed(e);
                else
                    AddAutofill(e);
            }
        }

        public void AddPreDeterminedEvent(Event e, int i)
        {
            if (events[i].SpecifiedTime.StartTime.Hours < e.SpecifiedTime.EndTime.Hours)
                return;
            else if ((events[i].SpecifiedTime.StartTime.Hours == e.SpecifiedTime.EndTime.Hours) && (events[i].SpecifiedTime.StartTime.Minutes < e.SpecifiedTime.EndTime.Minutes))
                return;
            else if (events[i].SpecifiedTime.EndTime.Hours > e.SpecifiedTime.StartTime.Hours)
                return;
            else if ((events[i].SpecifiedTime.EndTime.Hours == e.SpecifiedTime.StartTime.Hours) && (events[i].SpecifiedTime.EndTime.Minutes > e.SpecifiedTime.StartTime.Minutes))
                return;
            else
                events.Add(e);
        }

        public void AddDueDated(Event e)
        {
            events.Add(e);
        }

        public void AddETATimed(Event e)
        {
            int allottedMins = 0;
            int etaMins = 0;
            int i = 0;
            bool hasAddedEvent = false;

            while (i < events.Count - 1 || hasAddedEvent)
            {
                if (events[i].SpecifiedTime.EndTime.Hours < events[i + 1].SpecifiedTime.StartTime.Hours)
                {
                    allottedMins += 60 - events[i].SpecifiedTime.EndTime.Minutes;
                    allottedMins += events[i + 1].SpecifiedTime.StartTime.Minutes;

                    int tempHours = events[i + 1].SpecifiedTime.StartTime.Hours - events[i].SpecifiedTime.EndTime.Hours;

                    if (tempHours > 2)
                        allottedMins += 60 * (tempHours - 1);

                }
                else if (events[i].SpecifiedTime.EndTime.Hours == events[i + 1].SpecifiedTime.StartTime.Hours)
                    allottedMins = events[i + 1].SpecifiedTime.StartTime.Minutes - events[i].SpecifiedTime.EndTime.Minutes;

                etaMins = e.SpecifiedTime.eta.Hours * 60 + e.SpecifiedTime.eta.Minutes;

                if (etaMins <= allottedMins)
                {
                    events.Add(e);
                    hasAddedEvent = true;
                }

                i++;
            }
        }

        public void AddAutofill(Event e)
        {
            events.Add(e);
        }

        public void SortEvents()
        {
            for (int i = 0; i < events.Count; i++)
            {
                bool swapElements = false;

                for (int j = i - 1; j > 0; j--)
                {
                    if (events[i].SpecifiedTime.StartTime.Hours > events[j].SpecifiedTime.StartTime.Hours)
                        swapElements = true;
                    else if ((events[i].SpecifiedTime.StartTime.Hours == events[j].SpecifiedTime.StartTime.Hours) && events[i].SpecifiedTime.StartTime.Minutes > events[i].SpecifiedTime.StartTime.Minutes)
                        swapElements = true;

                    if (swapElements)
                    {
                        Event temp = events[j];
                        events[j] = events[i];
                        events[i] = temp;
                    }
                }
            }
        }

        public void PartitionEvents()
        {
            List<Event> predetermined = new List<Event>();
            List<Event> dueDated = new List<Event>();
            List<Event> etaTimed = new List<Event>();
            List<Event> autofilled = new List<Event>();

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].SpecifiedTime != null)
                    predetermined.Add(events[i]);
                else if (events[i].dueDate != null)
                    dueDated.Add(events[i]);
                else if (events[i].SpecifiedTime.StartTime == null && events[i].SpecifiedTime.EndTime == null)
                    etaTimed.Add(events[i]);
                else
                    autofilled.Add(events[i]);

                events.Clear();
                events.TrimExcess();
                events.AddRange(predetermined);
                events.AddRange(dueDated);
                events.AddRange(etaTimed);
                events.AddRange(autofilled);

            }
        }
    }
}
