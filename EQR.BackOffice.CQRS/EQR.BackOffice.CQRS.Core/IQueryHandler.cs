using System.Threading;
using System.Threading.Tasks;

namespace EQR.BackOffice.CQRS.Core
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken());
    }
}