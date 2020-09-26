using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ScheduleInator
{
    public class FileEditor
    {
        string[] fileLines;
        public FileEditor()
        {
            fileLines = System.IO.File.ReadAllLines(@"D:\Hackathons\Clayhack\Clayhack2020\ScheduleInator\UserList.txt");
        }

        public List<Event> returnEvents()
        { 

        }
    }
}
