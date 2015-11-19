namespace Aurora.Core.Container
{
    public class CommandInfo
    {
        public CommandInfo(string title)
        {
            Title = title;
            Description = "";
            IconPath = "";
        }

        public string Title { get; }
        public string BarName { get; set; }

        public string Description { get; set; }
        public string IconPath { get; set; }
    }
}