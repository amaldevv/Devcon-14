
namespace WPAppStudio.BackgroundProcess.Ioc.Interfaces
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
