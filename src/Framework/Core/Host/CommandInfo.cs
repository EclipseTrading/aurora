namespace Aurora.Core.Host
{
    public class CommandInfo
    {
        public CommandInfo(string title)
        {
            Title = title;
        }

        public string Title { get; }
        public string BarName { get; set; }
    }
}