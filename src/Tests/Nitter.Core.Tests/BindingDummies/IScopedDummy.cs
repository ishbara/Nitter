namespace Nitter.Core.Tests.BindingDummies
{
    public interface IScopedDummy
    {
    }

    [BindOn(typeof(IScopedDummy), Lifetime.Scoped)]
    public class ScopedDummy : IScopedDummy
    {
    }
}
