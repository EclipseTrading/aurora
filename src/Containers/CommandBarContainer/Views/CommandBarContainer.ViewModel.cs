using System.Collections.ObjectModel;
using System.Windows.Controls;
using Aurora.Core;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandBarContainerViewModel : ViewModelBase 
    {
        private Orientation commandOrientation;
        private bool showContainerFrame;
        public ObservableCollection<CommandViewModel> Commands { get; } = new ObservableCollection<CommandViewModel>();

        public Orientation CommandOrientation
        {
            get { return commandOrientation; }
            set
            {
                commandOrientation = value;
                this.OnPropertyChanged();
            }
        }

        public bool ShowContainerFrame
        {
            get { return showContainerFrame; }
            set
            {
                showContainerFrame = value;
                this.OnPropertyChanged();
            }
        }
    }
}
