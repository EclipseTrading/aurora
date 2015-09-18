using System.ComponentModel;
using System.Runtime.CompilerServices;
using Aurora.Core.Annotations;

namespace Aurora.Core
{
    public class ViewModelBase : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged == null) {
                return;
            }

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}