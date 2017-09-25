namespace Aurora.Core.Test
{
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
}