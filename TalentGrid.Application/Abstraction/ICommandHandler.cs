namespace TalentGrid.Application.Abstraction
{
    public interface ICommandHandler<TCommand>
    {
        Task Handle(TCommand command);
    }
    
}
