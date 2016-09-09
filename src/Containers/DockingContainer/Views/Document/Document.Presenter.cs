using System;
using Aurora.Core;
using Aurora.Core.ViewContainer;
using Microsoft.Practices.Prism.Commands;

namespace Aurora.DockingContainer.Views.Document
{
    public class DocumentPresenter : Presenter<DocumentViewModel, DocumentActivityInfo>, IViewContainerService
    {
        public event EventHandler RequestClose;

        public DocumentPresenter(DocumentActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }

        protected override void OnViewModelChanged()
        {
            ViewModel.CloseCommand = new DelegateCommand(OnRequestClose);
        }

        public void SetTitle(string title)
        {
            this.ViewModel.Title = title;
        }

        private void OnRequestClose()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }

    }
}
