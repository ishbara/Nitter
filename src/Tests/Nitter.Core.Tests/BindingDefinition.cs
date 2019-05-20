namespace Nitter.Core.Tests
{
    using System;

    public class BindingDefinition
    {
        public BindingDefinition(
            Type declaration,
            Type implementation,
            Lifetime lifeTime)
        {
            this.Declaration = declaration;
            this.Implementation = implementation;
            this.LifeTime = lifeTime;
        }

        public Type Declaration { get; }

        public Type Implementation { get; }

        public Lifetime LifeTime { get; }
    }
}
