using System.Collections.Generic;
using Aurora.Core.Workspace;

namespace Aurora.Core.Container
{
    public interface IWorkspaceContainerService : IViewContainerService
    {
        IReadOnlyList<WorkspaceViewConfig> GetWorkspaceViews();
        void CloseAllView();
    }
}
