using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace ScheduleInator
{
    public class FileEditor
    {
        List<Event> EventList = new List<Event>();
        public FileEditor(List<Event> EventList)
        {
            this.EventList = EventList;
        }

        public void SerializeEvents()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"D:\Hackathons\Clayhack\Clayhack2020\ScheduleInator\UserList.txt");
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(writer.BaseStream, EventList);
            writer.Close();
        }

        public List<Event> DeserializeEvents()
        {
            BinaryFormatter b = new BinaryFormatter();
            FileStream stream = new FileStream(@"D:\Hackathons\Clayhack\Clayhack2020\ScheduleInator\UserList.txt", FileMode.Open, FileAccess.Read);
            List<Event> e = (List<Event>)b.Deserialize(stream);

            return e;
        }
    }
}
