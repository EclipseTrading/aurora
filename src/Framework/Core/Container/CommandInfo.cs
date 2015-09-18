namespace Aurora.Core.Container
{
    public class CommandInfo
    {
        public CommandInfo(string title)
        {
            Title = title;
        }

        public string Title { get; private set; }
        public string BarName { get; set; }
    }
}