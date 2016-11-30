using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using FSappTest1.Model;
using FSappTest1.ViewModel;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;


namespace FSappTest1.ViewModel 
{
    public class FaellesMadMainView : INotifyPropertyChanged
    {

        /// <summary>
        /// Indsæt private instance fields som indeholder deltagerliste og menu liste.
        /// Json potential
        /// </summary>
        /// 

        private Model.AttendeeHome insertAttendee;
        private Model.AttendeeHomeList attendeeList;
        private Model.AttendeeHome selectedAttendee;

        private RelayCommand addAttendeeCommand;
        private RelayCommand removeAttendeeCommand;
        

        StorageFolder localfolder = null;
        //private readonly string filnavn = "JsonMenu.json";
        private readonly string filnavn = "JsonAttendee.json";

        /// <summary>
        /// Indsæt private instance fields for commands Add and Remove from AttendeesList
        /// Måske også en command med add remove MenuList? (Nyt cs eller insæt her.)
        /// </summary>
        /// 

        public FaellesMadMainView()
        {
            // Kalder objekt i AttendeeHome og AttendeeHomeList klasserne

            attendeeList = new Model.AttendeeHomeList();
            insertAttendee = new Model.AttendeeHome();
            selectedAttendee = new Model.AttendeeHome();

            //Kalder object fra RelayCommand klassen
            addAttendeeCommand = new RelayCommand(AddNewAttendee);
            removeAttendeeCommand = new RelayCommand(RemoveAttendeeInList);
            SaveAttendeeListCommand = new RelayCommand(SaveDataListAttendeeAsync);
            GetAttendeeListCommand = new RelayCommand(GetDataListAttendeeAsync);

            //Kalder objekter fra plan og planList klasserne?



            //Laver en instans af local folder.
            localfolder = ApplicationData.Current.LocalFolder;

        }


        /// <summary>
        /// Indsæt metoder som bruges i dette FaellesMadMainView
        /// Hust OnpropertyChanged(nameof()); i set funktionen i nogle metoder.
        /// </summary>
        /// 

            public Model.AttendeeHome InsertAttendee
        {
            get { return insertAttendee; }
            set { insertAttendee = value; }
        }

        public Model.AttendeeHomeList AttendeeList
        {
            get { return attendeeList;}
            set { attendeeList = value; }
        }

        public Model.AttendeeHome SelectedAttendee
        {
            get { return selectedAttendee; }
            set { selectedAttendee = value; OnPropertyChanged(nameof(SelectedAttendee)); }
        }
        
            public void AddNewAttendee()
        {
            AttendeeHome tempAttendee = new AttendeeHome();
            tempAttendee.HusNr = insertAttendee.HusNr;
            tempAttendee.NoAdults = insertAttendee.NoAdults;
            tempAttendee.NoKidsGr1 = insertAttendee.NoKidsGr1;
            tempAttendee.NoKidsGr2 = insertAttendee.NoKidsGr2;
            tempAttendee.NoKidsGr3 = insertAttendee.NoKidsGr3;

            attendeeList.Add(tempAttendee);

        }

        public void RemoveAttendeeInList()
        {
            attendeeList.Remove(selectedAttendee);
        }

        public RelayCommand AddAttendeeCommand
        {
            get { return addAttendeeCommand; }
            set { addAttendeeCommand = value; }
        }

        public RelayCommand RemoveAttendeeCommand
        {
            get { return removeAttendeeCommand; }
            set { removeAttendeeCommand = value; }
        }

        public RelayCommand SaveAttendeeListCommand { get; set; }
        public RelayCommand GetAttendeeListCommand { get; set; }

        public async void SaveDataListAttendeeAsync()
        {
            string JsonAttendee = this.AttendeeList.GetJsonAttendee();
            StorageFile file = await localfolder.CreateFileAsync(this.filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonAttendee);
        }

        public async void GetDataListAttendeeAsync()
        {
            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonAttendee = await FileIO.ReadTextAsync(file);

                this.AttendeeList.Clear();
                AttendeeList.InsertJson(jsonAttendee);
            }
            catch (Exception)
            {

                MessageDialog NoDataList = new MessageDialog("No saved list yet", "Error");
                await NoDataList.ShowAsync();
            }
        }

        /// <summary>
        /// Denne del er Planlægnings koden
        /// </summary>
        /// 

        // Instancefields for plan:

        // Plan properties og lister:

        private Model.Plan insertPlan;
        private Model.PlanList planList;
        private Model.Plan selectedPlan;

        private RelayCommand addToPlanList;
        private RelayCommand removeFromPlanList;

        private readonly string filnavn1 = "JsonPlan";

        //Metoder:

        public Model.Plan InserPlan
        {
            get { return insertPlan; }
            set { insertPlan = value; }
        }

        public Model.PlanList PlanList
        {
            get { return planList; }
            set { planList = value; }
        }

        public Model.Plan SelectedPlan
        {
            get { return selectedPlan; }
            set { selectedPlan = value; OnPropertyChanged(nameof(SelectedPlan)); }
        }

        public void AddNewPlanOfDay()
        {
            Plan tempPlan = new Plan();
            tempPlan.ChefKok = insertPlan.ChefKok;
            tempPlan.Help1 = insertPlan.Help1;
            tempPlan.Help2 = insertPlan.Help2;
            tempPlan.Help3 = insertPlan.Help3;
            tempPlan.ExtraHelp = insertPlan.ExtraHelp;
            tempPlan.Clean1 = insertPlan.Clean1;
            tempPlan.Clean2 = insertPlan.Clean2;
            tempPlan.Clean3 = insertPlan.Clean3;
            tempPlan.Clean4 = insertPlan.Clean4;
            tempPlan.Menu = insertPlan.Menu;

            PlanList.Add(tempPlan);
        }

        public void RemovePlanOfDayInList()
        {
            planList.Remove(selectedPlan);
        }

        //Command koder:

        public RelayCommand AddPlanOfDayCommand
        {
            get { return addToPlanList; }
            set { addToPlanList = value; }
        }

        public RelayCommand RemoveFromPlanList
        {
            get { return removeFromPlanList; }
            set { removeFromPlanList = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

    }
}
