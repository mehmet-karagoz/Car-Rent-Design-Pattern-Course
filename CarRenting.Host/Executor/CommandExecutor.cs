using CarRenting.Host.Interfaces;

namespace CarRenting.Host.Executor
{
    public static class CommandExecutor
    {
        public static void Execute(ICommand command)
        {
            command.Execute();
        }
    }
}
