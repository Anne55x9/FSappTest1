using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace FSappTest1.Model
{
    public class AttendeeHomeList: ObservableCollection<AttendeeHome>
    {

        /// <summary>
        /// Tilføjer herunder en default liste i mit view
        /// </summary>
        public AttendeeHomeList()
            :base()
        {
            this.Add(new AttendeeHome() { HusNr = 0, NoAdults = 0, NoKidsGr1 = 0, NoKidsGr2 = 0, NoKidsGr3 = 0});
            this.Add(new AttendeeHome() { HusNr = 1, NoAdults = 1, NoKidsGr1 = 1, NoKidsGr2 = 1, NoKidsGr3 = 2 });
            this.Add(new AttendeeHome() { HusNr = 2, NoAdults = 2, NoKidsGr1 = 2, NoKidsGr2 = 2, NoKidsGr3 = 2 });
        }

        /// <summary>
        /// Metode som giver Json syntax af AttendeeList. 
        /// </summary>
        /// <returns></returns>

        public string GetJsonAttendee()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        /// <summary>
        /// Metode som konverterer json syntax til chsharp - en form for genindlæsning af det gemte. 
        /// </summary>
        /// <param name="jsonAttendee"></param>

        public void InsertJson(string jsonAttendee)
        {
            List<AttendeeHome> nyListe = JsonConvert.DeserializeObject<List<AttendeeHome>>(jsonAttendee);
            foreach (var AttendeeHome in nyListe)
            {
                this.Add(AttendeeHome);
            }
        }

    }
}
