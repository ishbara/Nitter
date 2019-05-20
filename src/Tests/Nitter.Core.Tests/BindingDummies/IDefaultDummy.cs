namespace Nitter.Core.Tests.BindingDummies
{
    public interface IDefaultDummy
    {
    }

    [BindOn(typeof(IDefaultDummy))]
    public class DefaultDummy : IDefaultDummy
    {
    }
}
