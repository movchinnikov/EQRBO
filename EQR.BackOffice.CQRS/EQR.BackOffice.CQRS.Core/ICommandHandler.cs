using System.Threading;
using System.Threading.Tasks;

namespace EQR.BackOffice.CQRS.Core
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task Execute(TCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken());
    }
}