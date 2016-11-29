using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FSappTest1.Model
{
    public class Attendee
    {
        private int husNr;

        public int HusNr
        {
            get { return husNr; }
            set { husNr = value; }
        }

        private int noAdults;

        public int NoAdults
        {
            get { return noAdults; }
            set { noAdults = value; }
        }

        private int noKidsGr1;

        public int NoKidsGr1
        {
            get { return noKidsGr1; }
            set { noKidsGr1 = value; }
        }

        private int noKidsGr2;

        public int NoKidsGr2
        {
            get { return noKidsGr2; }
            set { noKidsGr2 = value; }
        }

        private int noKidsGr3;

        public int NoKidsGr3
        {
            get { return noKidsGr3; }
            set { noKidsGr3 = value; }
        }


        public override string ToString()
        {
            return "Huset Nr er: " + HusNr +"." + " Antal Voksne er: " + NoAdults + "." + "Antal Børn i alderen 7-15 år er: " + NoKidsGr1 + "." + "Antal Børn i alderen 3-6 år: " + NoKidsGr2 + "."+ "Antal Børn i alderen 0-2 er: " + NoKidsGr3 + ".";
        }
    }
}
