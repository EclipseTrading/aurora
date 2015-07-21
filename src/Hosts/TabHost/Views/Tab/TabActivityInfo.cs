using Aurora.Core.Activities;

namespace Aurora.TabHost.Views.Tab
{
    public class TabActivityInfo : ActivityInfo
    {
        public TabActivityInfo(string title, bool isCloseable)
        {
            Title = title;
            IsCloseable = isCloseable;
        }

        public string Title { get;  }
        public bool IsCloseable { get; }
    }
}