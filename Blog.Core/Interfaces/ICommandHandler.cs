namespace Blog.Core.Interfaces
{
    public interface ICommandHandler { }

    public interface ICommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
