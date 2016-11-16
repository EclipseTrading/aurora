using System.Windows;
using Aurora.Core;
using Aurora.Core.Actions;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    internal class TestWorkspaceActionHandler : IHandler
    {
        public bool Execute(ActionEvent evt)
        {
            MessageBox.Show(Application.Current.MainWindow, $"Command handled in {this.GetType().Name}");
            return true;
        }
    }
}