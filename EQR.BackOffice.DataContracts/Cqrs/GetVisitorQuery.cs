using System;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class GetVisitorQuery : IQuery<VisitorResponse>
    {
        public string Id { get; private set; }

        public GetVisitorQuery(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Не указан идентификатор", nameof(id));

            Id = id;
        }
    }
}