using System;

namespace Aurora.Core
{
    public class ViewDefinition
    {
        public ViewDefinition(Type presenterType)
        {
            this.PresenterType = presenterType;
        }

        public Type PresenterType { get; }
        public Type ViewModelType => GetPresenterTypeArguments(PresenterType)[0];

        public Type ViewType => GetPresenterTypeArguments(PresenterType)[1];

        private static Type[] GetPresenterTypeArguments(Type presenterType)
        {
            return presenterType.GetInterface("IPresenter").GenericTypeArguments;
        }

    }
}