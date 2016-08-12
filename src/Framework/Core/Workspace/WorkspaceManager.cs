using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Core.Container;

namespace Aurora.Core.Workspace
{
    public class WorkspaceManager : IWorkspaceManager
    {
        private readonly Dictionary<string, IWorkspace> workspaces = new Dictionary<string, IWorkspace>();

        public WorkspaceManager(IViewFactory viewFactory, IViewManager viewManager)
        {
            var defaultWorkspace = new Workspace("default", viewFactory, viewManager);
            this.workspaces.Add("default", defaultWorkspace);
            this.CurrentWorkspace = defaultWorkspace;
        }

        public IWorkspace CurrentWorkspace { get; private set; }

        public async Task AddWorkspace(string name, IWorkspace workspace)
        {
            workspaces[name] = workspace;
            await Task.FromResult(0);
        }

        public async Task RemoveWorkspace(string name)
        {
            if (workspaces.ContainsKey(name))
            {
                workspaces.Remove(name);
            }

            await Task.FromResult(0);
        }

        public bool HasWorkspace(string name)
        {
            return workspaces.ContainsKey(name);
        }

        public async Task ChangeWorkspace(string name)
        {
            if (workspaces.ContainsKey(name))
            {
                if (CurrentWorkspace != null)
                {
                    await this.CurrentWorkspace.CloseAllView();
                }

                this.CurrentWorkspace = workspaces[name];
                await this.CurrentWorkspace.ShowAllView();

            }

        }
    }
}
