using System;
using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Request;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class UpdateAdmissionCommand : ICommand
    {
        public string VisitorId { get; set; }
        public string AdmissionId { get; set; }

        public string Meeting { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public IEnumerable<int> Floors { get; set; }

        public string Description { get; set; }

        public UpdateAdmissionCommand(string visitorId, UpdateAdmissionRequest request)
        {
            if (string.IsNullOrEmpty(visitorId))
                throw new ArgumentException("Ид посетителя не указан", nameof(visitorId));
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Данные для обновления не указаны");

            VisitorId = visitorId;
            AdmissionId = request.AdmissionId;
            Meeting = request.Meeting;
            DateFrom = request.DateFrom;
            DateTo = request.DateTo;
            Floors = request.Floors;
            Description = request.Description;
        }
    }
}