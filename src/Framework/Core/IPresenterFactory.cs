using System;
using System.Threading.Tasks;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public interface IViewFactory
    {
        Task<ActiveView> CreateActiveViewAsync(IActivity activity, Type presenterType, params object[] parameters);
    }
}