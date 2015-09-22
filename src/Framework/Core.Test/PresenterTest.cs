using System.Windows;
using Aurora.Core.Activities;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Aurora.Core.Test
{
    [TestFixture]
    public class PresenterTest
    {
        [Test, RequiresSTA]
        public async void FactoryWireUpTest()
        {
            var container = new UnityContainer();

            var factory = new ViewFactory(container, new ViewModelResolver(), new NamingConventionTypeResolver<FrameworkElement>("Presenter", "View"));
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

    public class TestPresenter : Presenter<TestViewModel>
    {
        public TestPresenter(ActivityInfo viewActivityInfo) : base(viewActivityInfo)
        {
        }
    }

    public class TestViewModel : ViewModelBase
    {
        private string testProperty;

        public string TestProperty
        {
            get { return testProperty; }
            set
            {
                testProperty = value;
                this.OnPropertyChanged();
            }
        }
    }

    public class TestView : FrameworkElement
    {

    }
}
