namespace Nitter.Core
{
    using System;

    /// <summary> Identifies the type which should be used for auto binding a certain interface. </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class BindOnAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BindOnAttribute"/>
        /// class with default scope of Transient. </summary>
        /// <param name="bindingType">  The type which will be bound to this implementation
        /// (e.g. interface type). Provided type should be implemented by the attributed type. </param>
        public BindOnAttribute(Type bindingType)
        {
            // Default binding scope
            this.BindingScope = Lifetime.Transient;
            this.ServiceType = bindingType;
        }

        /// <summary> Gets the type which this implementation will auto bind on. </summary>
        public Type ServiceType { get; }

        /// <summary> Gets or sets the auto binding scope. (Transient, Singleton). </summary>
        public Lifetime BindingScope { get; set; }
    }
}