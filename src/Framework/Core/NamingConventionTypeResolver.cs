using System;

namespace Aurora.Core
{
    public class NamingConventionTypeResolver<TTargetType> : IRelatedTypeResolver<TTargetType>
    {
        private readonly string sourceSuffix;
        private readonly string targetSuffix;

        public NamingConventionTypeResolver(string sourceSuffix, string targetSuffix)
        {
            this.sourceSuffix = sourceSuffix;
            this.targetSuffix = targetSuffix;
        }

        public Type ResolveType(Type relatedType)
        {
            if (!relatedType.Name.EndsWith(sourceSuffix))
                return null;

            var rawName = relatedType.Name.Substring(0, relatedType.Name.Length - sourceSuffix.Length);
            var typeName = rawName + targetSuffix;
            var fullName = relatedType.AssemblyQualifiedName?.Replace(relatedType.Name, typeName);
            return fullName == null ? null : Type.GetType(fullName, false);
        }
    }
}