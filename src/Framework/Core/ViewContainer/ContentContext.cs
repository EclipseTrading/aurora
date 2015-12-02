using System.Windows;

namespace Aurora.Core.ViewContainer
{
    public class ContentContext : ViewModelBase
    {
        private FrameworkElement mainContent;
        private FrameworkElement dialogContent;
        private bool isOpenDialog;

        public FrameworkElement MainContent
        {
            get { return this.mainContent; }
            set
            {
                this.mainContent = value;
                this.OnPropertyChanged();
            }
        }

        public FrameworkElement DialogContent
        {
            get { return this.dialogContent; }
            set
            {
                this.dialogContent = value;
                this.OnPropertyChanged();
            }
        }


        public bool IsOpenDialog
        {
            get { return this.isOpenDialog; }
            set
            {
                this.isOpenDialog = value;
                this.OnPropertyChanged();
            }
        }

    }
}
