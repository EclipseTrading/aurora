using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{
    
    public class Workspace : IWorkspace
    {
        private string name;
        private readonly List<WorkspaceItem> viewList = new List<WorkspaceItem>();
        public Workspace(string name, IViewFactory viewFactory, IViewManager viewManager)
        {
            this.name = name;
            this.ViewFactory = viewFactory;
            this.ViewManager = viewManager;
        }

        private IViewFactory ViewFactory { get; }

        private IViewManager ViewManager { get; }

        public async Task CreateView(Type presenterType, string viewName, WorkspaceLocation location, JObject customData)
        {
            var info = new ViewActivityInfo(viewName);
            info.WorkspaceLocation = location;
            info.ViewData = customData;
            var activeView = await ViewFactory.CreateActiveViewAsync(null, presenterType, info);
            var workspaceItem = new WorkspaceItem(info, presenterType, activeView);
            viewList.Add(workspaceItem);
            await ShowView(workspaceItem);
        }

        public async Task CloseAllView()
        {
            //not implement now
            await Task.FromResult(0);
        }

        public async Task ShowAllView()
        {
            foreach (var v in viewList)
            {
                await ShowView(v);
            }
        }

        private async Task ShowView(WorkspaceItem item)
        {
            await ViewManager.AddViewAsync(item.View, item.ViewInfo);
        }


    }
}
