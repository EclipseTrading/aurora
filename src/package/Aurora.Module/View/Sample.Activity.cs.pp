using Aurora.Core.Activities;

namespace $rootnamespace$.Views.Sample
{
    [ActivityInfo(typeof(SampleActivityInfo))]
    public class SampleActivity : ViewActivity<SamplePresenter, SampleViewModel, SampleView, SampleActivityInfo>
    {
        public SampleActivity(SampleActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
