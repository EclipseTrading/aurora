using System;
using System.Linq;

namespace Aurora.Core
{
    public class ViewModelResolver : IRelatedTypeResolver<IViewModel>
    {
        public Type ResolveType(Type relatedType)
        {
            var presenterInterface = relatedType.GetInterface(typeof (IPresenter<>).FullName);
            if(presenterInterface == null) {
                return null;
            }
            var viewModelType = presenterInterface.GenericTypeArguments.FirstOrDefault();
            return viewModelType;
        }
    }
}