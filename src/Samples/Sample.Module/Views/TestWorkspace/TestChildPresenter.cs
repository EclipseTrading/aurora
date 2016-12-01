using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestChildPresenter : WorkspaceViewPresenter<TestChildViewModel>
    {
        private readonly IActionService actionService;
        
        public TestChildPresenter(IActionService actionService, IActionHandlerService actionHandlerService) : base(new ViewActivityInfo(null), actionHandlerService)
        {
            Debug.WriteLine("Create TestChildViewPresenter");
            this.actionService = actionService;
        }

        protected override void OnInitialized()
        {
            var action = actionService.GetAction("action1");
            //this.RegisterActionHandler(action, new TestActionHandler("TestChildPresenter"));
            var action2 = actionService.GetAction("action2");
            this.RegisterActionHandler(action2, new TestActionHandler("TestChildPresenter"));
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.Title = "Child view";
        }
    }
}