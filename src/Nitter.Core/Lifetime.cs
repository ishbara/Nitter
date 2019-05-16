namespace Nitter.Core
{
    /// <summary> Lifetime for the binding of dependencies. </summary>
    public enum Lifetime
    {
        /// <summary>A new instance will be created every time it is requested.</summary>
        Transient,

        /// <summary>A new instance will be created for each predefined scope
        /// (Web Request or any type of unit of work).</summary>
        /// <remarks>Same instance is returned within the scope.</remarks>
        Scoped,

        /// <summary>Only one instance will exists in the application domain,
        /// and it will be returned every time it is requested.
        /// The Singleton type must be thread-safe.</summary>
        Singleton
    }
}