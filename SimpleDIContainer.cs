
using System;
using System.Collections.Generic;
using System.Linq;

namespace simple_di_container
{
    public class SimpleDIContainer
    {
        public enum LifeCycle
        {
            Singleton,
            Transient
        }

        private SimpleDIContainer() {
        }
        
        private static SimpleDIContainer _instance = new SimpleDIContainer();
        public static SimpleDIContainer Instance { get { return _instance; } }
        
        private readonly IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();

        public void Register<TTypeToResolve, TConcrete>()
        {
            Register<TTypeToResolve, TConcrete>(LifeCycle.Singleton);
        }

        public void Register<TTypeToResolve, TConcrete>(LifeCycle lifeCycle)
        {
            registeredObjects.Add(new RegisteredObject(typeof (TTypeToResolve), typeof (TConcrete), lifeCycle));
        }

        public TTypeToResolve GetInstance<TTypeToResolve>()
        {
            return (TTypeToResolve) ResolveObject(typeof (TTypeToResolve));
        }

        private object ResolveObject(Type typeToResolve)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new Exception(string.Format(
                    "The type {0} has not been registered", typeToResolve.Name));
            }
            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance == null || 
                registeredObject.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
            }
            return registeredObject.Instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}