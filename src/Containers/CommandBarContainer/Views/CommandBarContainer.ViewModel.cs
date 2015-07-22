using System.Collections.ObjectModel;
using Aurora.Core;

namespace Aurora.CommandBarContainer.Views
{
    public class CommandBarContainerViewModel : ViewModelBase 
    {
        public ObservableCollection<CommandViewModel> Commands { get; } = new ObservableCollection<CommandViewModel>();
    }
}
