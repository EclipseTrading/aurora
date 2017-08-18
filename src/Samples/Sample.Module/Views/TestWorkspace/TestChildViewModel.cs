using System.Diagnostics;
using System.Windows.Input;
using Aurora.Core;
using Prism.Commands;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestChildViewModel : ViewModelBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickCommand
        {
            get
            {
                var cmd = new DelegateCommand(ExecuteCommand, CanExecute);
                return cmd;
            }
        }

        private void ExecuteCommand()
        {
            Debug.WriteLine("Command executed");
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}