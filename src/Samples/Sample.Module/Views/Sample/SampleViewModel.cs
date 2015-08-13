using System.Windows.Input;
using Aurora.Core;
using Microsoft.Practices.Prism.Commands;

namespace Aurora.Sample.Module.Views.Sample
{
    public class SampleViewModel : ViewModelBase
    {
        private string title;
        private string name;
        private string message;
        private double immediate;

        private double delayed;
        private int delay;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                this.OnPropertyChanged();
            }
        }

        public DelegateCommand OkCommand { get; set; }


        public ICommand NewViewCommand { get; set; }

        public double Immediate
        {
            get { return immediate; }
            set
            {
                immediate = value;
                this.OnPropertyChanged();
            }
        }


        public double Delayed
        {
            get { return delayed; }
            set
            {
                delayed = value;
                this.OnPropertyChanged();
            }
        }

        public int Delay
        {
            get { return delay; }
            set
            {
                delay = value;
                this.OnPropertyChanged();
            }
        }
    }
}
