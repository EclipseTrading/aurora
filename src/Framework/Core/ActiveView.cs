using System.Windows;
using Aurora.Core.Activities;
using System;

namespace Aurora.Core
{
    public class ActiveView<TPresenter> : ActiveView where TPresenter : IPresenter
    {
        public ActiveView(TPresenter presenter, IViewModel viewModel, FrameworkElement view, IActivity activity = null) 
            : base(presenter, viewModel, view, activity)
        {
        }

        public new TPresenter Presenter => (TPresenter)base.Presenter;
    }

    public class ActiveView : IDisposable
    {
        public ActiveView(IPresenter presenter, IViewModel viewModel, FrameworkElement view, IActivity activity = null)
        {
            Presenter = presenter;
            ViewModel = viewModel;
            View = view;
            Activity = activity;
        }

        public IPresenter Presenter { get; }
        public IViewModel ViewModel { get; private set; }
        public FrameworkElement View { get; private set; }
        public IActivity Activity { get; private set; }

        public void Dispose()
        {
            Presenter.Dispose();
            ViewModel.Dispose();
            Activity?.Dispose(); 

            if (View is IDisposable)
            {
                IDisposable o = View as IDisposable;
                o.Dispose();
            }
        }
    }
}