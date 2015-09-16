using Aurora.Core;

namespace Aurora.Hosting
{
    public class ApplicationWindowViewModel : ViewModelBase, IApplicationWindowViewModel
    {
        private string windowName;
        private string applicationName;

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
    }
}