using Aurora.Core.Activities;
using Microsoft.Practices.Prism.Commands;
using System.Threading.Tasks;

namespace Aurora.Core.Dialog
{
    public abstract class DialogViewPresenter<TViewModel, TResult> : ViewPresenter<TViewModel, ViewActivityInfo>, 
                                                            IDialogViewPresenter<TResult> 
                                                            where TViewModel : DialogViewModel
                                                            where TResult : DialogResult
                                                            
    {
        private TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
        public DialogViewPresenter() : base(new ViewActivityInfo(null))
        {

        }
       

        public Task<TResult> ShowAsync()
        {
            this.ViewModel.IsOpen = true;
            return tcs.Task;
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.CancelCommand = new DelegateCommand(async () => await OnCancel() );
            this.ViewModel.CompleteCommand = new DelegateCommand(async () => await OnComplete());
        }

        protected async Task OnCancel()
        {
            this.ViewModel.IsOpen = false;
            TResult result = await CreateResult(true);
            this.tcs.TrySetResult(result);
        }

        protected async Task OnComplete()
        {
            this.ViewModel.IsOpen = false;
            TResult result = await CreateResult(false);
            this.tcs.TrySetResult(result);
        }

        protected abstract Task<TResult> CreateResult(bool isCancel);

      
    }
}
