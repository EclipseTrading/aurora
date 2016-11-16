using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core.Actions
{
    public interface IHandlerService
    {
        void Execute(ActionEvent evt);
        void RegisterHandler(IAction action, IHandler handler);
    }
}
