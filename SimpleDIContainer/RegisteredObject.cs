using System;

namespace simple_di_container
{
    public class RegisteredObject
    {
        public Type TypeToResolve { get; private set; }
        public Type ConcreteType { get; private set; }
        public object Instance { get; private set; }
        public SimpleDIContainer.LifeCycle LifeCycle { get; private set; }

        public RegisteredObject(Type typeToResolve, Type concreteType, SimpleDIContainer.LifeCycle lifeCycle)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
            LifeCycle = lifeCycle;
        }

        public RegisteredObject(Type typeToResolve, Type concreteType, SimpleDIContainer.LifeCycle lifeCycle, object instance)
        {
            this.TypeToResolve = typeToResolve;
            this.ConcreteType = concreteType;
            this.LifeCycle = lifeCycle;
            this.Instance = Instance;
        }

        internal void CreateInstance(params object[] args)
        {
            this.Instance = Activator.CreateInstance(this.ConcreteType, args);
        }
    }
}