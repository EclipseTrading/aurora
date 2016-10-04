using System.Collections.ObjectModel;
using System.Windows.Controls;
using Aurora.Core;
using Aurora.Core.Container;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandBarContainerViewModel : ViewModelBase 
    {
        private Orientation commandOrientation;
        private bool showContainerFrame;
        public ObservableCollection<CommandBarItem> Commands { get; } = new ObservableCollection<CommandBarItem>();

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
