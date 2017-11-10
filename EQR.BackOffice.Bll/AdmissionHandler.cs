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
    public sealed class AdmissionHandler :
        ICommandHandler<CreateAdmissionCommand>,
        ICommandHandler<DeleteAdmissionCommand>,
        ICommandHandler<UpdateAdmissionCommand>,
        IQueryHandler<GetAdmissionQuery, AdmissionResponse>,
        IQueryHandler<GetAdmissionsQuery, IEnumerable<AdmissionResponse>>
    {
        private readonly IAdmissionRepository _admissionRepository;

        public AdmissionHandler(IAdmissionRepository admissionRepository)
        {
            _admissionRepository = admissionRepository;
        }

        public async Task Execute(CreateAdmissionCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var admission = new Admission(cmd);
            await _admissionRepository.Create(admission);
        }

        public async Task<AdmissionResponse> Execute(GetAdmissionQuery cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var entity = await _admissionRepository.Get(new ObjectId(cmd.VisitorId), new ObjectId(cmd.AdmissionId));
            return new AdmissionResponse(entity);
        }

        public async Task<IEnumerable<AdmissionResponse>> Execute(GetAdmissionsQuery cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var entities = await _admissionRepository.GetAllByVisitor(new ObjectId(cmd.VisitorId));
            var dtos = entities.Select(x => new AdmissionResponse(x));
            return dtos;
        }

        public async Task Execute(DeleteAdmissionCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            await _admissionRepository.Delete(new ObjectId(cmd.VisitorId), new ObjectId(cmd.AdmissionId));
        }

        public async Task Execute(UpdateAdmissionCommand cmd, CqrsContext ctx, CancellationToken cancellationToken = new CancellationToken())
        {
            var entity = new Admission(cmd);

            await _admissionRepository.Update(entity);
        }
    }
}