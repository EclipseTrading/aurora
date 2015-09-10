using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using Aurora.Core;
using Aurora.Core.Activities;
using Aurora.Core.Container;
using Aurora.Core.ViewContainer;
using Aurora.Sample.Module.Shared;
using Aurora.Sample.Module.Views.ChildView;
using Microsoft.Practices.Prism.Commands;
using IViewContainerService = Aurora.Core.ViewContainer.IViewContainerService;

namespace Aurora.Sample.Module.Views.Sample
{

    public class SamplePresenter : ViewPresenter<SampleViewModel, SampleViewActivityInfo>, IViewContainerAware
    {
        private readonly SampleViewActivityInfo activityInfo;
        private readonly IActivityService activityService;

        private Subject<double> subject;
        private IDisposable delayDisposable;
         

        public SamplePresenter(SampleViewActivityInfo activityInfo, IActivityService activityService) : base(activityInfo)
        {
            this.activityInfo = activityInfo;
            this.activityService = activityService;
        }
        public IViewContainerService ViewContainerService { get; set; }

        protected async override void OnViewModelChanged()
        {
            base.OnViewModelChanged();

            ViewContainerService?.SetTitle("Sample View");

            this.ViewModel.Title = activityInfo.Title;

            this.OnViewModelPropertyChanged(vm => vm.Title, () => ViewContainerService?.SetTitle(ViewModel.Title));

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

            var random = new Random();

            subject = new Subject<double>();
            Observable.Interval(TimeSpan.FromMilliseconds(1000))
                .Select(_ => Math.Round(random.NextDouble(), 6))
                .Subscribe(s => subject.OnNext(s));

            
            subject.Subscribe(d => ViewModel.Immediate = d);

            this.OnViewModelPropertyChanged(vm => vm.Delay, InitDelay);

            ViewModel.Delay = 0;

            ViewModel.ChildView = await this.AddChildViewAsync(typeof (ChildPresenter));
        }

        private void InitDelay()
        {
            this.delayDisposable?.Dispose();
            this.delayDisposable = subject.Delay(TimeSpan.FromMilliseconds(ViewModel.Delay)).Subscribe(d => ViewModel.Delayed = d);
        }
    }
}
