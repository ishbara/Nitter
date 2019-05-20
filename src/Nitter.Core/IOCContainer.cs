namespace Nitter.Core
{
    using System;

    /// <summary> Represents an IoC container. </summary>
    public interface IOCContainer
    {
        /// <summary>
        /// Binds the specified implementation to the declaration with given lifetime.
        /// </summary>
        /// <param name="declaration">Type of the declaration of a service. (e.g. interface).</param>
        /// <param name="implementation">Type of the implementation of a service. (e.g. concrete class).</param>
        /// <param name="lifetime">Object lifetime of the binding.</param>
        void Bind(Type declaration, Type implementation, Lifetime lifetime);

        /// <summary> Gets an instance of T injected with all dependencies. </summary>
        /// <typeparam name="T">Type of the object that is requested.</typeparam>
        /// <returns>A new instance of requested type.</returns>
        T Resolve<T>()
            where T : class;
    }
}