using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Aurora.Core;
using Aurora.Core.Container;
using Aurora.Sample.Module.Shared;
using Aurora.Sample.Module.Views.ChildView;
using Microsoft.Practices.Prism.Commands;
using System.Threading.Tasks;
using Aurora.Controls;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Sample.Module.Views.Dialog;

namespace Aurora.Sample.Module.Views.Sample
{
    public class SamplePresenter : ViewPresenter<SampleViewModel, SampleViewActivityInfo>, IHostWindowManager
    {
        private readonly SampleViewActivityInfo activityInfo;
        private readonly IActivityService activityService;

        private Subject<double> subject;
        private IDisposable delayDisposable;
        private IDisposable observableDisposable;
        private IDisposable subDisposable;

        public SamplePresenter(SampleViewActivityInfo activityInfo, IActivityService activityService, IActionHandlerService actionHandlerService)
            : base(activityInfo, actionHandlerService)
        {
            this.activityInfo = activityInfo;
            this.activityService = activityService;
        }

        public ITitleBarSettings TitleBarSettings { get; } = new DefaultTitleBarSettings();

        protected override async void OnViewModelChanged()
        {
            base.OnViewModelChanged();

            TitleBarSettings.HeaderContent = "Sample View";

            this.ViewModel.Title = activityInfo.Title;

            this.OnViewModelPropertyChanged(vm => vm.Title, () => TitleBarSettings.HeaderContent = ViewModel.Title);

            this.ViewModel.OkCommand =
                new DelegateCommand(() => ViewModel.Message = string.Format(activityInfo.MessageFormat, ViewModel.Name),
                () => !string.IsNullOrEmpty(ViewModel.Name));

            this.OnViewModelPropertyChanged(vm => vm.Name,
                () => ViewModel.OkCommand.RaiseCanExecuteChanged());

            this.ViewModel.NewViewCommand = new DelegateCommand(
                () => activityService.StartActivityAsync(new SampleViewActivityInfo("Sample View", HostLocation.Center, true)
                {
                    MessageFormat = activityInfo.MessageFormat
                }),
                () => true);

            this.ViewModel.ShowDialogCommand = new DelegateCommand(async () => await GetDialogResultAsync());

            var random = new Random();

            subject = new Subject<double>();
            observableDisposable = Observable.Interval(TimeSpan.FromMilliseconds(1000))
                .Select(_ => Math.Round(random.NextDouble(), 6))
                .Subscribe(s => subject.OnNext(s));

            subDisposable = subject.Subscribe(d => ViewModel.Immediate = d);

            this.OnViewModelPropertyChanged(vm => vm.Delay, InitDelay);

            ViewModel.Delay = 0;

            ViewModel.ChildView = await this.AddChildViewAsync(typeof(ChildPresenter));
        }

        private void InitDelay()
        {
            this.delayDisposable?.Dispose();
            this.delayDisposable = subject.Delay(TimeSpan.FromMilliseconds(ViewModel.Delay)).Subscribe(d => ViewModel.Delayed = d);
        }

        private async Task GetDialogResultAsync()
        {
            var result = await ShowDialogAsync<SampleDialogResult>(typeof(SampleDialogPresenter));
            string output = result.ExtraResult;
        }


        public override void Dispose()
        {
            this.delayDisposable?.Dispose();  
            this.observableDisposable?.Dispose();
            this.subDisposable?.Dispose();
        }

        public Action CloseAction { get; set; }
    }
}
