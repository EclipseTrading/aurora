using System;

namespace Aurora.Core.Container
{
    public class ViewSettings : ViewModelBase
    {
        private string title;

        public ViewSettings()
        {
            this.Location = HostLocation.Center;
        }

        public HostLocation Location { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                title = value; 
                this.OnPropertyChanged();
            }
        }

        public bool IsCloseable { get; set; }
    }
}