using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Aurora.Core.Actions;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Aurora.Core.Test
{
    [TestFixture]
    public class PresenterTest
    {
        [Test, Apartment(ApartmentState.STA)]
        public async Task FactoryWireUpTest()
        {
            var container = new UnityContainer();
            container.RegisterType<IActionHandlerService, DefaultActionHandlerService>();

            var factory = new ViewFactory(container, new ViewModelResolver(), 
                new NamingConventionTypeResolver<FrameworkElement>("Presenter", "View"));
            var activeView = await factory.CreateActiveViewAsync<TestPresenter>();
            var presenter = activeView.Presenter;

            var propertySet = false;

            presenter.OnViewModelPropertyChanged(vm => vm.TestProperty, () => propertySet = true);

            Assert.IsFalse(propertySet);
            Assert.IsNull(presenter.ViewModel.TestProperty);

            presenter.ViewModel.TestProperty = "Test";

            Assert.IsTrue(propertySet);
            Assert.AreEqual(presenter.ViewModel.TestProperty, "Test");
        }
    }
}
