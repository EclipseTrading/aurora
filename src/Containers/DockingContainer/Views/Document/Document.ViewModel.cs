using System.Windows.Input;
using Aurora.Core;

namespace Aurora.DockingContainer.Views.Document
{
    public class DocumentViewModel : ViewModelBase
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

        public ICommand CloseCommand { get; set; }
    }
}
