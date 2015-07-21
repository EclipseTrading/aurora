using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Activities;

namespace Aurora.Core
{
    public class Presenter<TViewModel> : Presenter<TViewModel, FrameworkElement, ViewActivityInfo>, IViewPresenter
        where TViewModel : IViewModel
    {
        public Presenter(ViewActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }


        public ViewActivityInfo ViewActivityInfo => this.ActivityInfo;
    }

    public class Presenter<TViewModel, TView> : Presenter<TViewModel, TView, ActivityInfo>
        where TView : FrameworkElement where TViewModel : IViewModel
    {
        public Presenter(ActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }

    public class Presenter<TViewModel, TView, TActivityInfo> : IPresenter<TViewModel, TView>
            where TViewModel : IViewModel
            where TView : FrameworkElement
            where TActivityInfo : ActivityInfo
    {
        private readonly Dictionary<string, List<Action>> propertyChangeActions = new Dictionary<string, List<Action>>();
        private TViewModel viewModel;
        private TView view;

        public Presenter(TActivityInfo viewActivityInfo)
        {
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

        FrameworkElement IPresenter.View => this.View;

        public TView View
        {
            get { return view; }
            private set
            {
                view = value;
                OnViewChanged();
            }
        }

        public TActivityInfo ActivityInfo { get; }

        public virtual Task InitializeAsync(IViewModel vm, FrameworkElement v)
        {
            return this.InitializeAsync((TViewModel)vm, (TView)v);
        }

        public virtual async Task InitializeAsync(TViewModel vm, TView v)
        {
            await Task.Factory.StartNew(() =>
            {
                this.ViewModel = vm;
                this.View = v;
                this.ViewModel.PropertyChanged += ViewModelPropertyChanged;
            });

            this.View.DataContext = this.ViewModel;

            this.OnInitialized();
        }

        protected virtual void OnViewModelChanged() { }

        protected virtual void OnViewChanged() { }

        protected virtual void OnInitialized() { }

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