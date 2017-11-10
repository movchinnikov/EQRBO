using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class GetVisitorsQuery : IQuery<IEnumerable<VisitorResponse>>
    {
    }
}