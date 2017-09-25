using Aurora.Core.Actions;
using Aurora.Core.Activities;

namespace Aurora.Core.Test
{
    public class TestPresenter : Presenter<TestViewModel>
    {
        public TestPresenter(ActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService)
            : base(viewActivityInfo, actionHandlerService)
        {
        }
    }
}