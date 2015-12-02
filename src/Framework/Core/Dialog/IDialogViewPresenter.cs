using System.Threading.Tasks;

namespace Aurora.Core.Dialog
{
    public interface IDialogViewPresenter
    {        
    }


    public interface IDialogViewPresenter<TResult> : IDialogViewPresenter where TResult : DialogResult 
    {
        Task<TResult> ShowAsync(); 
    }

}
