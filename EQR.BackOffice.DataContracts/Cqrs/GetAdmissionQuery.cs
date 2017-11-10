using System;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class GetAdmissionQuery : IQuery<AdmissionResponse>
    {
        public string Id { get; private set; }

        public GetAdmissionQuery(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Ид не валидный", nameof(id));
            Id = id;
        }
    }
}