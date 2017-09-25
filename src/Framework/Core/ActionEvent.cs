using Aurora.Core.Actions;

namespace Aurora.Core
{
    public class ActionEvent
    {
        public IAction Action { get; }
        public IEventContext Context {get; }

        public ActionEvent(IAction action, IEventContext context)
        {
            Action = action;
            Context = context;
        }
    }
}
