using System;
using Aurora.Core;
using Aurora.Core.ViewContainer;
using Microsoft.Practices.Prism.Commands;

namespace Aurora.TabHost.Views.Tab
{
    public class TabPresenter : Presenter<TabViewModel, TabView, TabActivityInfo>, IViewContainerService
    {
        public event EventHandler RequestClose;

        public TabPresenter(TabActivityInfo viewActivityInfo)
            : base(viewActivityInfo)
        {
        }

        protected override void OnViewModelChanged()
        {
            base.OnViewModelChanged();
            
            this.ViewModel.Header = ActivityInfo.Title;
            this.ViewModel.IsCloseable = ActivityInfo.IsCloseable;
            
            ViewModel.CloseCommand = new DelegateCommand(OnRequestClose);
        }

        private void OnRequestClose()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }

        public void SetTitle(string title)
        {
            this.ViewModel.Header = title;
        }

        public void SetIsCloseable(bool isCloseable)
        {
            this.ViewModel.IsCloseable = isCloseable;
        }
    }
}
