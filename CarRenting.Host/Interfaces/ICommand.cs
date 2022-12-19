using CarRenting.Host.Common;

namespace CarRenting.Host.Interfaces
{
    public interface ICommand<T>
    {
        Response<T> Execute();
    }
}
