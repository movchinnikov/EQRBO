using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Cqrs;
using EQR.BackOffice.DataContracts.Entities;
using EQR.BackOffice.DataContracts.Responses;
using EQR.BackOffice.DAL.Repositories;
using MongoDB.Bson;

namespace EQR.BackOffice.Bll
{
    public sealed class VisitorHandler :
        ICommandHandler<CreateVisitorCommand>,
        IAfterCommandHandler<CreateVisitorCommand>,
        ICommandHandler<UpdateVisitorCommand>,
        ICommandHandler<DeleteVisitorCommand>,
        IQueryHandler<GetVisitorQuery, VisitorResponse>,
        IQueryHandler<GetVisitorsQuery, IEnumerable<VisitorResponse>>
    {
        private readonly ICqrsDispatcher _cqrsDispatcher;
        private readonly IVisitorsRepository _visitorsRepository;
        private readonly IAdmissionRepository _admissionRepository;

        public VisitorHandler(
            IVisitorsRepository visitorsRepository, 
            IAdmissionRepository admissionRepository, 
            ICqrsDispatcher cqrsDispatcher)
        {
            _visitorsRepository = visitorsRepository;
            _admissionRepository = admissionRepository;
            _cqrsDispatcher = cqrsDispatcher;
        }

        public async Task<IEnumerable<VisitorResponse>> Execute(GetVisitorsQuery cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var entities = await _visitorsRepository.GetAll();

            var dtos = entities.Select(x => new VisitorResponse(x));
            return dtos;
        }

        public async Task<VisitorResponse> Execute(GetVisitorQuery cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var entity = await _visitorsRepository.GetById(new ObjectId(cmd.Id));

            return new VisitorResponse(entity);
        }

        public async Task Execute(CreateVisitorCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var visitor = new Visitor(cmd);
            await _visitorsRepository.Create(visitor);
        }

        public async Task AfterExecute(CreateVisitorCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var command = new CreateAdmissionCommand(cmd);
            await _cqrsDispatcher.ExecuteCommand(command, ctx, cancellationToken);
        }

        public async Task Execute(UpdateVisitorCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var visitor = new Visitor(cmd);
            await _visitorsRepository.Update(visitor);
        }

        public async Task Execute(DeleteVisitorCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            await _visitorsRepository.Delete(new ObjectId(cmd.Id));
        }
    }
}