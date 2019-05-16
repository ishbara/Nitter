namespace Nitter.Core.Tests
{
    using System;
    using System.Collections.Generic;

    public class MockDI : IOCContainer
    {
        public MockDI()
        {
            this.Bindings = new Dictionary<Type, BindingDefinition>();
        }

        public Dictionary<Type, BindingDefinition> Bindings { get; }

        public void Bind(Type definition, Type implementation, Lifetime lifetime)
        {
            this.Bindings.Add(
                definition,
                new BindingDefinition(definition, implementation, lifetime));
        }

        public T Resolve<T>()
            where T : class
        {
            throw new NotSupportedException("No need for mocking");
        }
    }
}
