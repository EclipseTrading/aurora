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

            var factory = new PresenterFactory(container);
            var presenter = await factory.CreatePresenterAsync<TestPresenter, TestViewModel, TestView>();

            var propertySet = false;

            presenter .OnViewModelPropertyChanged(vm => vm.TestProperty, () => propertySet = true);

            Assert.IsFalse(propertySet);
            Assert.IsNull(presenter.ViewModel.TestProperty);

            presenter.ViewModel.TestProperty = "Test";

            Assert.IsTrue(propertySet);
            Assert.AreEqual(presenter.ViewModel.TestProperty, "Test");
        }

        internal class TestPresenter : Presenter<TestViewModel, TestView> 
        {
            public TestPresenter(ActivityInfo viewActivityInfo) : base(viewActivityInfo)
            {
            }
        }

        internal class TestViewModel : ViewModelBase
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

        internal class TestView : FrameworkElement
        {

        }
    }
}
