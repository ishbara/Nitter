namespace Nitter.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    /// <summary> Provides methods for automatically binding dependent types in an assembly. </summary>
    public class AssemblyAutoBinder
    {
        private readonly IOCContainer container;
        private Lifetime defaultLifetime;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyAutoBinder"/> class.
        /// </summary>
        /// <param name="container">IOC container instance where
        /// the bindings will be registered.</param>
        public AssemblyAutoBinder(IOCContainer container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
            this.defaultLifetime = Lifetime.Transient;
        }

        /// <summary>
        /// Sets the default lifetime to be used for binding.
        /// </summary>
        /// <param name="lifetime">Default lifetime.</param>
        /// <returns>Current instance of <see cref="AssemblyAutoBinder"/>.</returns>
        public AssemblyAutoBinder WithDefaultLifetime(Lifetime lifetime)
        {
            this.defaultLifetime = lifetime;
            return this;
        }

        /// <summary> Auto binds all referenced types in calling assembly. </summary>
        /// <param name="assembly">The assembly which holds the types to be bound.</param>
        /// <remarks> This method should only be called once at the start of process execution. </remarks>
        /// <returns>The container instance where the dependency bindings registered.</returns>
        public IOCContainer Bind(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (!type.IsClass)
                {
                    continue;
                }

                var bindingAttributes =
                    type.GetCustomAttributes<BindOnAttribute>(false).ToList();

                if (!bindingAttributes.Any())
                {
                    continue;
                }

                foreach (BindOnAttribute bindingAttribute in bindingAttributes)
                {
                    this.container.Bind(
                        bindingAttribute.ServiceType,
                        type,
                        bindingAttribute.Lifetime ?? this.defaultLifetime);
                }
            }

            return this.container;
        }
    }
}