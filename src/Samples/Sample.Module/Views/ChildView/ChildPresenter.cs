using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;

namespace Aurora.Sample.Module.Views.ChildView
{
    public class ChildPresenter : ViewPresenter<ChildViewModel, ViewActivityInfo>
    {
        private readonly IActionHandlerService actionHandlerService;

        public ChildPresenter(ViewActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService) : base(viewActivityInfo, actionHandlerService)
        {
            this.actionHandlerService = actionHandlerService;
        }
    }
}
