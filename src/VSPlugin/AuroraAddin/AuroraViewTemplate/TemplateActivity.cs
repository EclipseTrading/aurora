using Aurora.Core.Activities;

namespace $rootnamespace$.Views.$safeitemname$
{
    [ActivityInfo(typeof($safeitemname$ActivityInfo))]
    public class $safeitemname$Activity : ViewActivity<$safeitemname$Presenter, $safeitemname$ActivityInfo>
    {
        public $safeitemname$Activity($safeitemname$ActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
