using Aurora.Core;

namespace $rootnamespace$.Views.Sample
{
    public class SamplePresenter : Presenter<SampleViewModel, SampleView, SampleActivityInfo>
    {
        public SamplePresenter(SampleActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
