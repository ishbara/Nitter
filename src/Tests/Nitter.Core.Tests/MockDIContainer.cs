namespace Nitter.Core.Tests
{
    using System;
    using System.Collections.Generic;

    public class MockDIContainer : IOCContainer
    {
        public MockDIContainer()
        {
            this.Bindings = new Dictionary<Type, BindingDefinition>();
        }

        public Dictionary<Type, BindingDefinition> Bindings { get; }

        public void Bind(Type declaration, Type implementation, Lifetime lifetime)
        {
            this.Bindings.Add(
                declaration,
                new BindingDefinition(declaration, implementation, lifetime));
        }

        public T Resolve<T>()
            where T : class
        {
            throw new NotSupportedException("No need for mocking");
        }
    }
}
