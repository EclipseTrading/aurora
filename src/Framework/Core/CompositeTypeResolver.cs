using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Core
{
    public class CompositeTypeResolver<TTargetType> : IRelatedTypeResolver<TTargetType>
    {
        private readonly IEnumerable<IRelatedTypeResolver<TTargetType>> resolvers;

        public CompositeTypeResolver(params IRelatedTypeResolver<TTargetType>[] resolvers) 
            : this((IEnumerable<IRelatedTypeResolver<TTargetType>>)resolvers)
        {
        }

        public CompositeTypeResolver(IEnumerable<IRelatedTypeResolver<TTargetType>> resolvers)
        {
            this.resolvers = resolvers;
        } 

        public Type ResolveType(Type relatedType)
        {
            return resolvers.Select(r => r.ResolveType(relatedType))
                .FirstOrDefault(r => r != null);
        }
    }
}