using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Actions;

namespace Aurora.Core
{

    public class ActionEvent
    {
        public IAction Action { get; private set;}
        public IEventContext EvtCtx {get; private set; }

        public ActionEvent(IAction action, IEventContext evtCtx)
        {
            Action = action;
            EvtCtx = evtCtx;
        }
    }
}
