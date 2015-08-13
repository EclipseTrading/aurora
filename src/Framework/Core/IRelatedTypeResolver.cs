using System;

namespace Aurora.Core
{
    /// <summary>
    /// Resolves one type based on another
    /// </summary>
    /// <typeparam name="TTargetType">Type parameter specified for dependency injection</typeparam>
    public interface IRelatedTypeResolver<TTargetType>
    {
        Type ResolveType(Type relatedType);
    }
}