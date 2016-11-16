using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Actions;

namespace Aurora.Core
{
    public sealed class RootDependencyHandler : IDependencyHandler
    {
        private readonly IHandlerService handlerService;

        public RootDependencyHandler(IHandlerService handlerService)
        {
            this.handlerService = handlerService;
        }

        public IDependencyHandler Parent => null;
        public Func<ActionEvent, bool> Delegate
        {
            set { throw new NotSupportedException("Delegate not supported"); }
        }

        public bool Execute(ActionEvent evt)
        {
            handlerService.Execute(evt);
            return true;
        }
    }
}
