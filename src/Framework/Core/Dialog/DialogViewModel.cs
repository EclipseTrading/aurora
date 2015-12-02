using System.Windows.Input;

namespace Aurora.Core.Dialog
{
    public class DialogViewModel : ViewModelBase
    {
        private ICommand completeCommand;
        private ICommand cancelCommand;
        private bool isOpen;


        public ICommand CompleteCommand
        {
            get { return this.completeCommand; }
            set
            {
                this.completeCommand = value;
                this.OnPropertyChanged();
            }
        }


        public ICommand CancelCommand
        {
            get { return this.cancelCommand; }
            set
            {
                this.cancelCommand = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsOpen
        {
            get { return this.isOpen; }
            set
            {
                this.isOpen = value;
                this.OnPropertyChanged();
            }
        }
    }
}
