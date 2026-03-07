namespace TalentGrid.Application.Abstraction
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
