using Aurora.Core;

namespace Aurora.DockingHost.Views.Document
{
    public class DocumentPresenter : Presenter<DocumentViewModel, DocumentView, DocumentActivityInfo>
    {
        public DocumentPresenter(DocumentActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
