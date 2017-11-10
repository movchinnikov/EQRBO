using System;
using System.Threading;
using System.Threading.Tasks;
using Castle.Windsor;

namespace EQR.BackOffice.CQRS.Core
{
    public sealed class CqrsDispatcher : ICqrsDispatcher
    {
        private readonly IWindsorContainer _container;

        public CqrsDispatcher(IWindsorContainer container)
        {
            _container = container;
        }

        public async Task ExecuteCommand<TCommand>(TCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken()) where TCommand : ICommand
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            var handler = _container.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
                throw new NotImplementedException($"Не определен обработчик для команды {cmd.GetType()}");

            await handler.Execute(cmd, ctx, cancellationToken);
        }

        public async Task<TResult> ExecuteQuery<TQuery, TResult>(TQuery query, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
            where TQuery : IQuery<TResult>
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query), "Запрос не передан");

            var handler = _container.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
                throw new NotImplementedException($"Не определен обработчик для запроса {query.GetType()}");

            return await handler.Execute(query, ctx, cancellationToken);
        }
    }
}