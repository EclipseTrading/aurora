using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core;
using Aurora.Core.Actions;
using System.Windows;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestActionHandler : IActionHandler
    {
        private readonly string src;

        public TestActionHandler(string src)
        {
            this.src = src;
        }

        public bool Execute(ActionEvent evt)
        {

            MessageBox.Show(evt.EvtCtx.ActiveWindow ?? Application.Current.MainWindow, $"Command handled by {src}\n\nparams=\n" +
                                                                                       $"{string.Join(Environment.NewLine, evt.Action.GetParameters().Select(kvp => kvp.Key + ':' + kvp.Value.ToString()))}");
            return true;
        }
    }
}
