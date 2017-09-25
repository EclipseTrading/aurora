using System;
using System.Threading.Tasks;

namespace Aurora.Core.Workspace
{

    public interface IWorkspace
    {
        Task CreateView(Type presenterType, string id, string title, object viewData, ViewLocation location);
        Task LoadLayout(WorkspaceLayout layout);
        void CloseAllView();
        WorkspaceLayout GetCurrentLayout();
    }
}
