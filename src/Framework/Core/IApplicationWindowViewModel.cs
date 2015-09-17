namespace Aurora.Core
{
    public interface IApplicationWindowViewModel
    {
        string ApplicationName {  get; set; }
        string WindowName { get; set; }
        string IconPath { get; set; }
    }
}
