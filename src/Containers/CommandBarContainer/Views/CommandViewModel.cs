using System.Windows.Input;
using Aurora.Core;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandViewModel : ViewModelBase
    {
        private string title;
        private string description;
        private string iconPath;

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

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                this.OnPropertyChanged();
            }
        }
        

        public string IconPath
        {
            get { return iconPath; }
            set
            {
                iconPath = value;
                this.OnPropertyChanged();
            }
        }
    }
}