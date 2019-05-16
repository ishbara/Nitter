namespace Nitter.Core.Tests
{
    using System;

    public class BindingDefinition
    {
        public BindingDefinition(
            Type definition,
            Type implementation,
            Lifetime lifeTime)
        {
            this.Definition = definition;
            this.Implementation = implementation;
            this.LifeTime = lifeTime;
        }

        public Type Definition { get; }

        public Type Implementation { get; }

        public Lifetime LifeTime { get; }
    }
}
