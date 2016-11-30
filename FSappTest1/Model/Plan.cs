using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FSappTest1.Model
{
    public class Plan
    {
        private string chefKok;

        public string ChefKok
        {
            get { return chefKok; }
            set { chefKok = value; }
        }

        private string help1;

        public string Help1
        {
            get { return help1; }
            set { help1 = value; }
        }

        private string help2;

        public string Help2
        {
            get { return help2; }
            set { help2 = value; }
        }

        private string help3;

        public string Help3
        {
            get { return help3; }
            set { help3 = value; }
        }

        private string clean1;

        public string Clean1
        {
            get { return clean1; }
            set { clean1 = value; }
        }

        public string clean2;

        public string Clean2
        {
            get { return clean2;}
            set { clean2 = value; }
        }

        public string clean3;

        public string Clean3
        {
            get { return clean3; }
            set { clean3 = value; }
        }

        private string clean4;

        public string Clean4
        {
            get { return clean4;}
            set { clean4 = value; }
        }

        private string extraHelp;
        public string ExtraHelp
        {
            get { return extraHelp; }
            set { extraHelp = value; }
        }

        private string menu;

        public string Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        public override string ToString()
        {
            return "Chefkokken er: " + ChefKok + "," + "Help1 er:" + Help1 + "," + "Help2 er:" + Help2 + "," + "Help3 er:" + Help3
              + "." + "Clean1 er:" + Clean1 + ","+ "Clean2 er:" + Clean2 + "," + "Clean3 er:" + Clean3 + "," + "Clean4 er:" + Clean4 
              + ","+ "ExtraHelp er:" +ExtraHelp + "." + "Menuer er:" + Menu + "."; 
        }

    }
}

