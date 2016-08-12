using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;
using Aurora.Sample.Module.Views.ChildView;
using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json.Linq;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestWorkspacePresenter : WorkspaceViewPresenter<TestWorkspaceViewModel>
    {
        private readonly IWorkspaceManager workspaceManager;
        public TestWorkspacePresenter(ViewActivityInfo info, IWorkspaceManager workspaceManager) : base(info)
        {
            this.workspaceManager = workspaceManager;
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.CreateViewCommand = new DelegateCommand(async () => { await this.CreateView(); });
            this.ViewModel.SelectedWindowType = WindowType.Floating;
            this.ViewModel.SelectedViewType = ViewType.Custom;
            this.ViewModel.Title = "Testing";
            this.ViewModel.Width = 800;
            this.ViewModel.Height = 600;
            this.ViewModel.JsonInput = "{}";
        }

        private async Task CreateView()
        {
            if (this.ViewModel.SelectedWindowType == WindowType.Floating)
            {
                var location = new WorkspaceLocation()
                {
                    FloatingTop = this.ViewModel.Top,
                    FloatingLeft = this.ViewModel.Left,
                    FloatingWidth = this.ViewModel.Width,
                    FloatingHeight = this.ViewModel.Height,
                    IsFloating = true
                };


                var data = JObject.Parse(this.ViewModel.JsonInput);
                await workspaceManager.CurrentWorkspace.CreateView(GetPresenterType(), this.ViewModel.Title, location, data);
            }
            else
            {
                var location = new WorkspaceLocation()
                {
                    GroupIdx = this.ViewModel.GroupIdx,
                    TabOrder = this.ViewModel.TabOrder,
                    IsSelected = false,
                    IsFloating = false
                };
                var data = JObject.Parse(this.ViewModel.JsonInput);
                await workspaceManager.CurrentWorkspace.CreateView(GetPresenterType(), this.ViewModel.Title, location, data);

            }
        }

        private Type GetPresenterType()
        {
            if (this.ViewModel.SelectedViewType == ViewType.Custom)
                return typeof(CustomPresenter);
            else if (this.ViewModel.SelectedViewType == ViewType.TestWorkspace)
                return typeof(TestWorkspacePresenter);
            else
                return null;
        }


    }
}
