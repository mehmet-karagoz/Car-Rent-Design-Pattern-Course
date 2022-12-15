using CarRenting.Host.Common;

namespace CarRenting.Host.Executor
{
    public class CommandExecutor
    {
        public void ExecuteCommand(BaseCommand command)
        {
            command.Execute();
        }
    }
}
