namespace Aurora.Core.Dialog
{
    public enum DialogCloseReason
    {
        Complete, Cancel
    };

    public class DialogResult
    {      
        public DialogCloseReason CloseReason { get; set; }

    }
}
