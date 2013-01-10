using System;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;

namespace blazey.registry
{
    public class RegistryResolver : ISubDependencyResolver
    {
        private readonly IKernel _kernel;

        public RegistryResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver,
                               ComponentModel model, DependencyModel dependency)
        {
            if (dependency.TargetItemType == null) return false;
            if (dependency.TargetItemType.IsGenericType &&
                dependency.TargetItemType.GetGenericTypeDefinition() != typeof (Registry<>)) return false;

            var itemType = GetItemType(dependency.TargetItemType);

            return itemType != null && _kernel.HasComponent(itemType);
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver,
                              ComponentModel model, DependencyModel dependency)
        {
            var candidateType = GetItemType(dependency.TargetItemType);
            var candidates = _kernel.ResolveAll(candidateType);

            var typeToConstruct = typeof (Registry<>).GetGenericTypeDefinition().MakeGenericType(new[] {candidateType});

            return Activator.CreateInstance(typeToConstruct, candidates);
        }

        private static Type GetItemType(Type targetItemType)
        {
            if (targetItemType == null)
            {
                return null;
            }
            if (targetItemType.IsArray)
            {
                return targetItemType.GetElementType();
            }
            if (targetItemType.IsGenericType == false || targetItemType.IsGenericTypeDefinition)
            {
                return null;
            }

            return targetItemType.GetGenericArguments()[0];
        }


    }
}