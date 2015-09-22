using Aurora.Core.Activities;

namespace $rootnamespace$.Views.Sample
{
    [ActivityInfo(typeof(SampleActivityInfo))]
    public class SampleActivity : ViewActivity<SamplePresenter, SampleActivityInfo>
    {
        public SampleActivity(SampleActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
