namespace Nitter.Core
{
    /// <summary> Scope for the auto binding of dependencies. </summary>
    public enum BindingScope
    {
        /// <summary>A new instance will be created every time it is requested.</summary>
        Transient,

        /// <summary>Only one instance will exists in the application domain,
        /// and it will be returned every time it is requested.
        /// The Singleton type must be thread-safe.</summary>
        Singleton
    }
}