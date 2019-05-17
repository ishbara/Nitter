namespace Nitter.Core
{
    using System;

    /// <summary> Identifies the type which should be used for auto binding a certain interface. </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class BindOnAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BindOnAttribute"/> class.
        /// </summary>
        /// <param name="bindingType"> The type which will be bound to this implementation
        /// (e.g. interface type). Provided type should be implemented by the attributed type. </param>
        public BindOnAttribute(Type bindingType)
        {
            this.ServiceType = bindingType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BindOnAttribute"/> class.
        /// with a predefined lifetime.
        /// </summary>
        /// <param name="bindingType">  The type which will be bound to this implementation
        /// (e.g. interface type). Provided type should be implemented by the attributed type. </param>
        /// <param name="lifetime">Lifetime of this binding.</param>
        public BindOnAttribute(Type bindingType, Lifetime lifetime)
        {
            this.ServiceType = bindingType;
            this.Lifetime = lifetime;
        }

        /// <summary> Gets the type which this implementation will auto bind on. </summary>
        public Type ServiceType { get; }

        /// <summary> Gets the auto binding scope. (Transient, Scoped, Singleton). </summary>
        public Lifetime? Lifetime { get; }
    }
}