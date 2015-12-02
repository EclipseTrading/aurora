using Aurora.Core.Dialog;
using System.Windows.Input;

namespace Aurora.Sample.Module.Views.Dialog
{
    public class SampleDialogViewModel : DialogViewModel
    {

        private int dummyData;
        private ICommand showDialogCommand;

        public int DummyData
        {
            get { return this.dummyData; }
            set
            {
                this.dummyData = value;
            }
        }

        public ICommand ShowDialogCommand
        {
            get { return this.showDialogCommand; }
            set
            {
                this.showDialogCommand = value;
                this.OnPropertyChanged();
            }
        }
    }
}
