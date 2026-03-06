namespace TalentGrid.Application.Abstraction
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command);
    }
}
