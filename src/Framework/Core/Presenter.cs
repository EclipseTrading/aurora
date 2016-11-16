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
        public Presenter(ActivityInfo viewActivityInfo, IDependencyHandler dependencyHandler)
            : base(viewActivityInfo, dependencyHandler)
        {
        }
    }

    public class Presenter<TViewModel, TActivityInfo> : IPresenter<TViewModel>
        where TViewModel : IViewModel
        where TActivityInfo : ActivityInfo
    {
        public IDependencyHandler DependencyHandler { get; }
        private readonly Dictionary<string, List<Action>> propertyChangeActions = new Dictionary<string, List<Action>>();
        private readonly Dictionary<IAction, IHandler> actionHandlers = new Dictionary<IAction, IHandler>();
        private TViewModel viewModel;

        public Presenter(TActivityInfo viewActivityInfo, IDependencyHandler dependencyHandler)
        {
            this.DependencyHandler = dependencyHandler;
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
            DependencyHandler.Delegate = (evt) => this.HandleAction(evt);

            this.OnInitialized();

            return Task.FromResult(false);
        }

        private bool HandleAction(ActionEvent evt)
        {
            if (actionHandlers.Count == 0 || evt.Action == null)
            {
                return false;
            }

            IHandler handler;
            return actionHandlers.TryGetValue(evt.Action, out handler) && handler.Execute(evt);
        }

        protected virtual void OnViewModelChanged() { }

        protected virtual void OnInitialized() { }

        protected void RegisterActionHandler(IAction action, IHandler handler)
        {
            actionHandlers[action] = handler;
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