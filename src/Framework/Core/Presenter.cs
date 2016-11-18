using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Aurora.Core.Actions;
using Aurora.Core.Activities;

namespace Aurora.Core
{

    public class Presenter<TViewModel> : Presenter<TViewModel, ActivityInfo>
        where TViewModel : IViewModel
    {
        public Presenter(ActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService)
            : base(viewActivityInfo, actionHandlerService)
        {
        }
    }

    public class Presenter<TViewModel, TActivityInfo> : IPresenter<TViewModel>
        where TViewModel : IViewModel
        where TActivityInfo : ActivityInfo
    {
        public IActionHandlerService ActionHandlerService { get; }
        private readonly Dictionary<string, List<Action>> propertyChangeActions = new Dictionary<string, List<Action>>();
        private TViewModel viewModel;

        public Presenter(TActivityInfo viewActivityInfo, IActionHandlerService actionHandlerService)
        {
            this.ActionHandlerService = actionHandlerService;
            this.ActivityInfo = viewActivityInfo;
        }

        IViewModel IPresenter.ViewModel => this.ViewModel;

        public TViewModel ViewModel
        {
            get { return viewModel; }
            private set
            {
                viewModel = value;
                OnViewModelChanged();
            }
        }

        public TActivityInfo ActivityInfo { get; }

        public virtual Task InitializeAsync(IViewModel vm)
        {
            return this.InitializeAsync((TViewModel)vm);
        }

        public virtual Task InitializeAsync(TViewModel vm)
        {
            this.ViewModel = vm;
            this.ViewModel.PropertyChanged += ViewModelPropertyChanged;

            this.OnInitialized();

            return Task.FromResult(false);
        }

        protected virtual void OnViewModelChanged() { }

        protected virtual void OnInitialized() { }

        protected void RegisterActionHandler(IAction action, IActionHandler actionHandler)
        {
            ActionHandlerService.RegisterHandler(action, actionHandler);
        }

        public void OnViewModelPropertyChanged<TPropertyType>(Expression<Func<TViewModel, TPropertyType>> property, Action propertyChangedAction, bool suppressInitial = false)
        {
            var name = property.GetName();
            if (!propertyChangeActions.ContainsKey(name))
            {
                propertyChangeActions[name] = new List<Action>();
            }
            propertyChangeActions[name].Add(propertyChangedAction);
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InvokeActions(this.propertyChangeActions, e.PropertyName);
        }

        protected static void InvokeActions(IReadOnlyDictionary<string, List<Action>> actions, string name)
        {
            if (!actions.ContainsKey(name)) return;

            var toInvoke = actions[name];
            toInvoke.ForEach(a => a());
        }

        public virtual void Dispose()
        {

        }
    }
}