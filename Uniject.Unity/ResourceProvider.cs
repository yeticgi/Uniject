using System;

namespace Uniject.Unity
{
    public class ResourceProvider<T> : Ninject.Activation.Provider<T> where T : class, IUnityObject {

        private IResourceLoader loader;
        public ResourceProvider(IResourceLoader loader) {
            this.loader = loader;
        }

        protected override T CreateInstance(Ninject.Activation.IContext context) {
            var resource = Scoping.getContextAttribute<ResourceAttribute>(context);
            if (resource == null) {
                throw new ArgumentException("Injected resources must have Resource attributes");
            }

            return loader.loadResource<T>(resource.Path);
        }
    }
}

