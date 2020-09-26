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

        public void doit()
        {
            for(int i = 0; i < events.Count; i++)
            {
                bool set = false;

                for(int j = 0; j < events.Count - 1; j++)
                {
                    if (events[i].SpecifiedTime.FixedTime)
                    {
                        set = true;
                        break;
                    }
                    else
                    {
                        if (events[j].SpecifiedTime == null)
                            continue;

                        Time end = events[j].SpecifiedTime.EndTime;
                        Time start = events[j + 1].SpecifiedTime.StartTime;

                        var t = events[i].SpecifiedTime;
                        int c = t.EndTime.Hours * 60 + t.EndTime.Minutes - t.StartTime.Hours * 60 - t.StartTime.Minutes;

                        int collective = start.Hours * 60 + start.Minutes - end.Hours * 60 - end.Minutes;
                        if (collective >= c)
                        {
                            events[i].SpecifiedTime.StartTime = new Time(end.Hours, end.Minutes);
                            events[i].SpecifiedTime.EndTime = new Time(end.Hours, end.Minutes);
                            events[i].SpecifiedTime.EndTime.addMins(c);
                        }
                        set = true;

                        break;
                    }
                }

                if(!set)
                {
                    events.RemoveAt(i);
                    i--;
                }
            }
        }

        public void AddPreDeterminedEvent(Event e)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].SpecifiedTime != null)
                {
                    if (events[i].SpecifiedTime.StartTime.Hours < e.SpecifiedTime.EndTime.Hours)
                        break;
                    else if ((events[i].SpecifiedTime.StartTime.Hours == e.SpecifiedTime.EndTime.Hours) && (events[i].SpecifiedTime.StartTime.Minutes < e.SpecifiedTime.EndTime.Minutes))
                        break;
                    else if (events[i].SpecifiedTime.EndTime.Hours > e.SpecifiedTime.StartTime.Hours)
                        break;
                    else if ((events[i].SpecifiedTime.EndTime.Hours == e.SpecifiedTime.StartTime.Hours) && (events[i].SpecifiedTime.EndTime.Minutes > e.SpecifiedTime.StartTime.Minutes))
                        break;
                    else
                        events.Add(e);
                }
            }
        }

        public void AddDueDated(Event e)
        {
            if (e.dueDate != null)
                events.Add(e);
        }

        public void AddETATimed(Event e)
        {
            int allottedMins = 0;
            int etaMins = 0;
            int i = 0;
            bool hasAddedEvent = false;

            if (e.SpecifiedTime.StartTime == null && e.SpecifiedTime.EndTime == null)
            {
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
        }

        public void autofill(Event e)
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
    }
}
//make sure eta is not too large
