using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace Aurora.Core
{
    public class RegionViewModel : ViewModelBase
    {
        private IRegionManager regionManager;

        [Dependency]
        public IRegionManager RegionManager
        {
            get { return regionManager; }
            set
            {
                regionManager = value;
                this.OnPropertyChanged();
            }
        }
    }
}