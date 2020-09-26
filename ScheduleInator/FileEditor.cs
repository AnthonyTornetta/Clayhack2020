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
            System.IO.StreamWriter writer = new StreamWriter(@"UserList.bin");
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(writer.BaseStream, EventList);
            writer.Close();
        }

        public List<Event> DeserializeEvents()
        {
            BinaryFormatter b = new BinaryFormatter();
            FileStream stream = new FileStream(@"UserList.bin", FileMode.Open, FileAccess.Read);
            List<Event> e = (List<Event>)b.Deserialize(stream);

            return e;
        }
    }
}
