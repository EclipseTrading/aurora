using System;

namespace Aurora.Core.Host
{
    public class ViewSettings : ViewModelBase
    {
        private string title;
        public HostLocation Location { get; set; } = HostLocation.Center;

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