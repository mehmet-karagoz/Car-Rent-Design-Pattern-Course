using CarRenting.Host.Common;
using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Executor
{
    public static class CommandExecutor<T>
    {
        public static Response<T> Execute(ICommand<T> command)
        {
            return command.Execute();
        }
    }
}
