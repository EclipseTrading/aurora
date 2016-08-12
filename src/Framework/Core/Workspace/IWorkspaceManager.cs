using System.Threading.Tasks;

namespace Aurora.Core.Workspace
{
    public interface IWorkspaceManager
    {
        IWorkspace CurrentWorkspace { get; }
        Task AddWorkspace(string name, IWorkspace workspace);
        Task RemoveWorkspace(string name);
        bool HasWorkspace(string name);
        Task ChangeWorkspace(string name);
    }
}
