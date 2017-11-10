using System.Threading;
using System.Threading.Tasks;

namespace EQR.BackOffice.CQRS.Core
{
    public interface IAfterCommandHandler<TCommand> 
        where TCommand : ICommand
    {
        Task AfterExecute(TCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken());
    }
}