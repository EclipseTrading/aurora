using Aurora.Core;
using Aurora.Core.Activities;

namespace Aurora.Sample.Module.Views.ChildView
{
    public class ChildPresenter : ViewPresenter<ChildViewModel, ViewActivityInfo>
    {
        public ChildPresenter(ViewActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
