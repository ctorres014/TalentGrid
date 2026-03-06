using Microsoft.Extensions.DependencyInjection;

namespace TalentGrid.Application.Abstraction
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
        {
            var handler = _provider
                .GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return await handler.Handle(query);
        }
    }
}
