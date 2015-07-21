using System.Windows.Input;
using Aurora.Core;

namespace Aurora.TabHost.Views.Tab
{
    public class TabViewModel : RegionViewModel
    {
        private string header;
        private bool isCloseable;

        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsCloseable
        {
            get { return isCloseable; }
            set
            {
                isCloseable = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand CloseCommand { get; set; }
    }
    
}
