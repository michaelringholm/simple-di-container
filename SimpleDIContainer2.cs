using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_di_container
{
    public class SimpleDIContainer2
    {
        Dictionary<Type, Func<object>> registrations = new Dictionary<Type, Func<object>>();

        public void Register<TService, TImpl>() where TImpl : TService {
            this.registrations.Add(typeof(TService), () => this.GetInstance<TService>(typeof(TImpl)));
        }

        public void Register<TService>(Func<TService> instanceCreator) {
            this.registrations.Add(typeof(TService), () => instanceCreator());
        }

        public void RegisterSingleton<TService>(TService instance) {
            this.registrations.Add(typeof(TService), () => instance);
        }

        public void RegisterSingleton<TService>(Func<TService> instanceCreator) {
            var lazy = new Lazy<TService>(instanceCreator);
            this.Register<TService>(() => lazy.Value);
        }

        public T GetInstance<T>(Type serviceType) {
            Func<object> creator;
            if (this.registrations.TryGetValue(serviceType, out creator)) return (T)creator();
            else if (!serviceType.IsAbstract) return (T)this.CreateInstance<T>(serviceType);
            else throw new InvalidOperationException("No registration for " + serviceType);
        }

        private T CreateInstance<T>(Type implementationType) {
            var ctor = implementationType.GetConstructors().Single();
            var parameterTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = parameterTypes.Select(t => ((T)this.GetInstance<T>(t))).ToArray();
            return (T)Activator.CreateInstance(implementationType, dependencies);
        }
    }

}