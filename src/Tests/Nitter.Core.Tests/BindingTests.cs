namespace Nitter.Core.Tests
{
    using Xunit;

    public class BindingTests
    {
        private readonly MockDIContainer container;
        private readonly AssemblyAutoBinder binder;

        public BindingTests()
        {
            this.container = new MockDIContainer();
            this.binder = new AssemblyAutoBinder(this.container);
        }

        [Fact]
        public void Binds_Types_In_Current_Assembly()
        {
            var usedContainer = this.binder.Bind(typeof(BindingTests).Assembly);

            Assert.Same(this.container, usedContainer);
            var definition = this.container.Bindings[typeof(IScopedDummy)];
            Assert.Equal(typeof(ScopedDummy), definition.Implementation);
            Assert.Equal(Lifetime.Scoped, definition.LifeTime);
        }

        [Fact]
        public void Binds_Types_With_Default_Lifetime()
        {
            var defaultLifetime = Lifetime.Singleton;

            var usedContainer = this.binder.
                WithDefaultLifetime(defaultLifetime)
                .Bind(typeof(BindingTests).Assembly);

            Assert.Same(this.container, usedContainer);
            var definition = this.container.Bindings[typeof(IDefaultDummy)];
            Assert.Equal(typeof(DefaultDummy), definition.Implementation);
            Assert.Equal(defaultLifetime, defaultLifetime);
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
        public interface IScopedDummy
        {
        }

        [BindOn(typeof(IScopedDummy), Lifetime.Scoped)]
        public class ScopedDummy : IScopedDummy
        {
        }

        public interface IDefaultDummy
        {
        }

        [BindOn(typeof(IDefaultDummy))]
        public class DefaultDummy : IDefaultDummy
        {
        }
#pragma warning restore SA1201 // Elements should appear in the correct order
    }
}
