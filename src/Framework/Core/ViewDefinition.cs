using System;

namespace Aurora.Core
{
    public class ViewDefinition
    {
        public ViewDefinition(Type presenterType)
        {
            this.PresenterType = presenterType;
        }

        public Type PresenterType { get; private set; }
        public Type ViewModelType
        {
            get { return GetPresenterTypeArguments(PresenterType)[0]; }
        }

        public Type ViewType
        {
            get { return GetPresenterTypeArguments(PresenterType)[1]; }
        }
        private static Type[] GetPresenterTypeArguments(Type presenterType)
        {
            return presenterType.GetInterface("IPresenter").GenericTypeArguments;
        }

    }
}