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
        List<Event> eventList = new List<Event>();

        public FileEditor(List<Event> eventList)
        {
            this.eventList = eventList;
        }

        public void SerializeEvents()
        {
            System.IO.StreamWriter writer = new StreamWriter(@"UserList.bin");
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(writer.BaseStream, eventList);
            writer.Close();
        }

        public List<Event> DeserializeEvents()
        {
            try
            {
                BinaryFormatter b = new BinaryFormatter();
                FileStream stream = new FileStream(@"UserList.bin", FileMode.Open, FileAccess.Read);
                List<Event> e = (List<Event>)b.Deserialize(stream);

                return e;
            }
            catch(Exception)
            {
                return new List<Event>();
            }
        }
    }
}
