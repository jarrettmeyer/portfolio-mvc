namespace Portfolio.Data.Commands
{
    public interface ICommandStore
    {
        TCommand GetCommand<TCommand>() where TCommand : AbstractCommand;
    }
}
