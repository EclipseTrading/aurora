using Aurora.Core.Activities;

namespace Aurora.DockingContainer.Views.Document
{
    public class DocumentActivity : ViewActivity<DocumentPresenter, DocumentActivityInfo>
    {
        public DocumentActivity(DocumentActivityInfo activityInfo) : base(activityInfo)
        {
        }
    }
}
