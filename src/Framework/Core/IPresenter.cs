using System;
using System.Threading.Tasks;
using System.Windows;

namespace Aurora.Core
{
    public interface IPresenter<TViewModel, TView> : IPresenter
        where TViewModel : IViewModel
        where TView : FrameworkElement
    {
        new TViewModel ViewModel { get;  }
        new TView View { get;  }

        Task InitializeAsync(TViewModel viewModel, TView view);
    }

    public interface IPresenter : IDisposable
    { 
        IViewModel ViewModel { get; }
        FrameworkElement View { get;  }

        Task InitializeAsync(IViewModel viewModel, FrameworkElement element);
    }
}