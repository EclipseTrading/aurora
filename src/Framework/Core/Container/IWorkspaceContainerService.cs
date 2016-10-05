using System.Threading.Tasks;
using Aurora.Core.Workspace;

namespace Aurora.Core.Container
{

    public interface IWorkspaceContainerService : IViewContainerService
    {
        Task<WorkspaceLayout> GetCurrentLayout();
        Task CloseAllView();
    }
}
