using Aurora.Core.Activities;
using Aurora.Core.ViewContainer;

namespace Aurora.Core
{
    public interface IViewPresenter
    {
        ViewActivityInfo ViewActivityInfo { get; }
        ContentContext ContentContext { get; set; }
    }
}