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
        IQueryHandler<GetAdmissionQuery, AdmissionResponse>
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
            var entity = await _admissionRepository.Get(new ObjectId(cmd.Id));
            return new AdmissionResponse(entity);
        }

        
    }
}