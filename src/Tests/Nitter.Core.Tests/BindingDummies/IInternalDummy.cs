namespace Nitter.Core.Tests.BindingDummies
{
    public interface IInternalDummy
    {
    }

    [BindOn(typeof(IInternalDummy))]
    internal class InternalDummy : IInternalDummy
    {
    }
}
