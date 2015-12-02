using System.Threading.Tasks;

namespace Aurora.Core.Dialog
{
 
    public interface IDialogViewPresenter<TResult> where TResult : DialogResult 
    {
        Task<TResult> ShowAsync(); 
    }

}
