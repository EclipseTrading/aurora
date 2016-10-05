using System;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{

    public interface IWorkspace
    {
        Task CreateView(Type presenterType, string id, string title, JObject viewData, ViewLocation location);
        Task CloseAllView();
        Task LoadLayout(WorkspaceLayout layout);
        Task<WorkspaceLayout> GetCurrentLayout();
        
    }
}
