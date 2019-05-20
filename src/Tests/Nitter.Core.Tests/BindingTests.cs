namespace Nitter.Core.Tests
{
    using Nitter.Core.Tests.BindingDummies;
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
            var declaration = this.container.Bindings[typeof(IScopedDummy)];
            Assert.Equal(typeof(ScopedDummy), declaration.Implementation);
            Assert.Equal(Lifetime.Scoped, declaration.LifeTime);
        }

        [Fact]
        public void Binds_Types_With_Default_Lifetime()
        {
            var defaultLifetime = Lifetime.Singleton;

            var usedContainer = this.binder.
                WithDefaultLifetime(defaultLifetime)
                .Bind(typeof(BindingTests).Assembly);

            Assert.Same(this.container, usedContainer);
            var declaration = this.container.Bindings[typeof(IDefaultDummy)];
            Assert.Equal(typeof(DefaultDummy), declaration.Implementation);
            Assert.Equal(defaultLifetime, defaultLifetime);
        }

        [Fact]
        public void Binds_Internal_Implementation()
        {
            var usedContainer = this.binder
                .Bind(typeof(BindingTests).Assembly);

            Assert.Same(this.container, usedContainer);
            var declaration = this.container.Bindings[typeof(IInternalDummy)];
            Assert.Equal(typeof(InternalDummy), declaration.Implementation);
        }

        [Fact]
        public void Binds_Inner_Types()
        {
            var usedContainer = this.binder
                .Bind(typeof(BindingTests).Assembly);

            Assert.Same(this.container, usedContainer);
            var declaration = this.container.Bindings[typeof(IInnerDummy)];
            Assert.Equal(typeof(InnerDummy), declaration.Implementation);
        }

#pragma warning disable SA1201 // Elements should appear in the correct order
        public interface IInnerDummy
        {
        }

        [BindOn(typeof(IInnerDummy))]
        public class InnerDummy : IInnerDummy
        {
        }
#pragma warning restore SA1201 // Elements should appear in the correct order
    }
}
