using System;
using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class GetAdmissionsQuery : IQuery<IEnumerable<AdmissionResponse>>
    {
        public string VisitorId { get; private set; }

        public GetAdmissionsQuery(string visitorId)
        {
            if (string.IsNullOrEmpty(visitorId))
                throw new ArgumentException("Ид посетителя не валидный", nameof(visitorId));
            VisitorId = visitorId;
        }
    }
}