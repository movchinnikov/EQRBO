﻿using System;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class GetAdmissionQuery : IQuery<AdmissionResponse>
    {
        public string VisitorId { get; private set; }
        public string AdmissionId { get; private set; }

        public GetAdmissionQuery(string visitorId, string admissionId)
        {
            if (string.IsNullOrEmpty(visitorId))
                throw new ArgumentException("Ид посетителя не валидный", nameof(visitorId));
            if (string.IsNullOrEmpty(admissionId))
                throw new ArgumentException("Ид допуска не валидный", nameof(admissionId));
            VisitorId = visitorId;
            AdmissionId = admissionId;
        }
    }
}