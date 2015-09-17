using Aurora.Core;

namespace Aurora.Hosting
{
    public class ApplicationWindowViewModel : ViewModelBase, IApplicationWindowViewModel
    {
        private string windowName;
        private string applicationName;
        private string iconPath;

        public string ApplicationName
        {
            get { return applicationName; }
            set
            {
                applicationName = value;
                this.OnPropertyChanged();
            }
        }

        public string WindowName
        {
            get { return windowName; }
            set
            {
                windowName = value;
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