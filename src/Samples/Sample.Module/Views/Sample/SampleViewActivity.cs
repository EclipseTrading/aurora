using Aurora.Core.Activities;
using Aurora.Sample.Module.Shared;

namespace Aurora.Sample.Module.Views.Sample
{
    [ActivityInfo(typeof(SampleViewActivityInfo))]
    public class SampleViewActivity : ViewActivity<SamplePresenter, SampleViewActivityInfo>
    {
        public SampleViewActivity(SampleViewActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
