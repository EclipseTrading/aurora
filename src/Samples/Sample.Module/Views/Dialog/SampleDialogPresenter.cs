using Aurora.Core.Dialog;
using Microsoft.Practices.Prism.Commands;
using System.Threading.Tasks;
using Aurora.Core;

namespace Aurora.Sample.Module.Views.Dialog
{
    
    public class SampleDialogPresenter : DialogViewPresenter<SampleDialogViewModel,SampleDialogResult>
    {

        public SampleDialogPresenter(IDependencyHandler dependencyHandler) : base(dependencyHandler)
        {
        }

        protected override void OnViewModelChanged()
        {
            base.OnViewModelChanged();

            this.ViewModel.ShowDialogCommand = new DelegateCommand(async () => await GetDialogResultAsync());

        }

        protected override Task<SampleDialogResult> CreateResult(bool isCancel)
        {
            if (isCancel)
            {
                return Task.FromResult(new SampleDialogResult()
                {
                    CloseReason = DialogCloseReason.Cancel,
                    ExtraResult = "cancelled"
                });
            }
            else
            {
                return Task.FromResult(new SampleDialogResult()
                {
                    CloseReason = DialogCloseReason.Complete,
                    ExtraResult = "normal return"
                });
            }
        }

        private async Task GetDialogResultAsync()
        {
            var result = await ShowDialogAsync<SampleDialogResult>(typeof(SampleDialogPresenter));

            SampleDialogResult dummyResult = result;

        }





    }
}
