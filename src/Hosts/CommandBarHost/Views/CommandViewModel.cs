using System.Windows.Input;
using Aurora.Core;

namespace Aurora.CommandBarHost.Views
{
    public class CommandViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand Command { get; set; }
    }
}