using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{
    public interface IWorkspace
    {
        Task CreateView(Type presenterType, string viewName, WorkspaceLocation location, JObject customData);
        Task CloseAllView();
        Task ShowAllView();
    }
}
