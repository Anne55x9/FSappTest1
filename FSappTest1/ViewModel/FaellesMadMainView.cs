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

        private Model.Attendee insertAttendee;
        private Model.AttendeeList attendeeList;
        private Model.Attendee selectedAttendee;

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
            // Kalder objekt i Attendee og AttendeeList klasserne

            attendeeList = new Model.AttendeeList();
            insertAttendee = new Model.Attendee();
            selectedAttendee = new Model.Attendee();

            //Kalder object fra RelayCommand klassen
            addAttendeeCommand = new RelayCommand(AddNewAttendee);
            removeAttendeeCommand = new RelayCommand(RemoveAttendeeInList);
            SaveAttendeeListCommand = new RelayCommand(SaveDataListAttendeeAsync);
            GetAttendeeListCommand = new RelayCommand(GetDataListAttendeeAsync);


            //Laver en instans af local folder.
            localfolder = ApplicationData.Current.LocalFolder;

        }


        /// <summary>
        /// Indsæt metoder som bruges i dette FaellesMadMainView
        /// Hust OnpropertyChanged(nameof()); i set funktionen i nogle metoder.
        /// </summary>
        /// 

            public Model.Attendee InsertAttendee
        {
            get { return insertAttendee; }
            set { insertAttendee = value; }
        }

        public Model.AttendeeList AttendeeList
        {
            get { return attendeeList;}
            set { attendeeList = value; }
        }

        public Model.Attendee SelectedAttendee
        {
            get { return selectedAttendee; }
            set { selectedAttendee = value; OnPropertyChanged(nameof(SelectedAttendee)); }
        }
        
            public void AddNewAttendee()
        {
            Attendee tempAttendee = new Attendee();
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
