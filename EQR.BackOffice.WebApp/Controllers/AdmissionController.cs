using System.Threading;
using System.Threading.Tasks;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Cqrs;
using EQR.BackOffice.DataContracts.Entities;
using EQR.BackOffice.DataContracts.Request;
using EQR.BackOffice.DataContracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EQR.BackOffice.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AdmissionController
    {
        private readonly ICqrsDispatcher _cqrsDispatcher;

        public AdmissionController(ICqrsDispatcher cqrsDispatcher)
        {
            _cqrsDispatcher = cqrsDispatcher;
        }

        [HttpPost]
        public async Task<AdmissionResponse> Create([FromBody] CreateAdmissionRequest request)
        {
            var cmd = new CreateAdmissionCommand(request);
            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());

            var query = new GetAdmissionQuery(request.VisitorId, cmd.Id);
            var response = await _cqrsDispatcher.ExecuteQuery<GetAdmissionQuery, AdmissionResponse>(query, null, new CancellationToken());

            return response;
        }
    }
}