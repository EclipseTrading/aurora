using Aurora.Core.Activities;

namespace Aurora.DockingHost.Views.Document
{
    public class DocumentActivity : ViewActivity<DocumentPresenter, DocumentViewModel, DocumentView, DocumentActivityInfo>
    {
        public DocumentActivity(DocumentActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
