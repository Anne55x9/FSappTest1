using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FSappTest1.ViewModel
{
    public class RelayCommand : ICommand
    {

        private Action methodToExecute = null;
        private Func<bool> methodToDetectCanExecute = null;

        private Action addNewAttendee;

        public RelayCommand(Action addNewAttendee)
        {
            this.addNewAttendee = addNewAttendee;
        }

        //Icommand implementerer en eventHandler med metoderne CanExecute og Execute

        public event EventHandler CanExecuteChanged;
        
        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }
        }


        public void Execute(object paramter)
        {
            this.addNewAttendee();
        }


    }
}
