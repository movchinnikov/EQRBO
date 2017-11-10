using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Cqrs;
using EQR.BackOffice.DataContracts.Request;
using EQR.BackOffice.DataContracts.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EQR.BackOffice.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class VisitorsController : Controller
    {
        private readonly ICqrsDispatcher _cqrsDispatcher;

        public VisitorsController(ICqrsDispatcher cqrsDispatcher)
        {
            _cqrsDispatcher = cqrsDispatcher;
        }

        [HttpGet]
        public async Task<IEnumerable<VisitorResponse>> Get()
        {
            var query = new GetVisitorsQuery();

            var response = await _cqrsDispatcher.ExecuteQuery<GetVisitorsQuery, IEnumerable<VisitorResponse>>(query, null, new CancellationToken());

            return response;
        }

        [HttpGet("{id}")]
        public async Task<VisitorResponse> Get(string id)
        {
            var query = new GetVisitorQuery(id);

            var response = await _cqrsDispatcher.ExecuteQuery<GetVisitorQuery, VisitorResponse>(query, null, new CancellationToken());

            return response;
        }

        [HttpPost]
        public async Task<VisitorResponse> Create([FromBody] CreateVisitorRequest request)
        {
            JsonConvert.SerializeObject(DateTime.UtcNow);
            var cmd = new CreateVisitorCommand(request);
            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());

            var query = new GetVisitorQuery(cmd.Id);
            var response = await _cqrsDispatcher.ExecuteQuery<GetVisitorQuery, VisitorResponse>(query, null, new CancellationToken());

            return response;
        }

        [HttpGet("{visitorId}/admissions/{admissionId}")]
        public async Task<AdmissionResponse> Get(string visitorId, string admissionId)
        {
            var query = new GetAdmissionQuery(visitorId, admissionId);

            var response = await _cqrsDispatcher.ExecuteQuery<GetAdmissionQuery, AdmissionResponse>(query, null, new CancellationToken());

            return response;
        }

        [HttpPatch("{visitorId}/admissions")]
        public async Task<AdmissionResponse> Update(string visitorId, [FromBody] UpdateAdmissionRequest request)
        {
            var cmd = new UpdateAdmissionCommand(visitorId, request);

            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());

            var query = new GetAdmissionQuery(visitorId, cmd.AdmissionId);
            var response = await _cqrsDispatcher.ExecuteQuery<GetAdmissionQuery, AdmissionResponse>(query, null, new CancellationToken());

            return response;
        }

        [HttpGet("{visitorId}/admissions")]
        public async Task<IEnumerable<AdmissionResponse>> GetAllByVisitor(string visitorId)
        {
            var query = new GetAdmissionsQuery(visitorId);

            var response = await _cqrsDispatcher.ExecuteQuery<GetAdmissionsQuery, IEnumerable<AdmissionResponse>>(query, null, new CancellationToken());

            return response;
        }

        [HttpDelete("{visitorId}/admissions/{admissionId}")]
        public async Task Delete(string visitorId, string admissionId)
        {
            var cmd = new DeleteAdmissionCommand(visitorId, admissionId);

            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());
        }

        [HttpPatch]
        public async Task<VisitorResponse> Update([FromBody] UpdateVisitorRequest request)
        {
            var cmd = new UpdateVisitorCommand(request);
            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());

            var query = new GetVisitorQuery(cmd.Id);
            var response = await _cqrsDispatcher.ExecuteQuery<GetVisitorQuery, VisitorResponse>(query, null, new CancellationToken());

            return response;
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            var cmd = new DeleteVisitorCommand(id);
            await _cqrsDispatcher.ExecuteCommand(cmd, null, new CancellationToken());
        }
    }
}