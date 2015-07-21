using System.Collections.ObjectModel;
using Aurora.Core;

namespace Aurora.CommandBarHost.Views
{
    public class CommandBarHostViewModel : ViewModelBase 
    {
        public ObservableCollection<CommandViewModel> Commands { get; } = new ObservableCollection<CommandViewModel>();
    }
}
