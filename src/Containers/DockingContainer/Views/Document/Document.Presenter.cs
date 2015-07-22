using Aurora.Core;

namespace Aurora.DockingContainer.Views.Document
{
    public class DocumentPresenter : Presenter<DocumentViewModel, DocumentView, DocumentActivityInfo>
    {
        public DocumentPresenter(DocumentActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }
}
