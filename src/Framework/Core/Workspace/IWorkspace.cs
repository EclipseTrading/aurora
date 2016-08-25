using System;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Aurora.Core.Workspace
{

    public interface IWorkspace
    {
        Task CreateFloatingView(Type presenterType, string viewName, JObject viewData, Rect location);
        Task CreateDockedView(Type presenterType, string viewName, JObject viewData, int groupIdx, int order, bool selected);
        Task ArrangeDocking(DockingConfig config);
        Task CloseAllView();
        Task LoadLayout(WorkspaceLayout layout);
        Task<WorkspaceLayout> GetCurrentLayout();
        
    }
}
