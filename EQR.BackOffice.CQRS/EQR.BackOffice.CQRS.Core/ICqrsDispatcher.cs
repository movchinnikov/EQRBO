using System.Threading;
using System.Threading.Tasks;

namespace EQR.BackOffice.CQRS.Core
{
    public interface ICqrsDispatcher
    {
        Task ExecuteCommand<TCommand>(TCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
            where TCommand : ICommand;

        Task<TResult> ExecuteQuery<TQuery, TResult>(TQuery query, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
            where TQuery : IQuery<TResult>;
    }
}