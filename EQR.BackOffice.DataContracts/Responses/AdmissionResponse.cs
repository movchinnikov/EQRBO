using System;
using System.Collections.Generic;
using EQR.BackOffice.DataContracts.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace EQR.BackOffice.DataContracts.Responses
{
    public sealed class AdmissionResponse
    {
        public string Id { get; private set; }

        public string Description { get; private set; }

        public string Meeting { get; private set; }

        public DateTime DateFrom { get; private set; }

        public DateTime DateTo { get; private set; }

        public IEnumerable<int> Floors { get; private set; }

        public AdmissionResponse(Admission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Сущность не передана");

            Id = entity.Id.ToString();
            Description = entity.Description;
            Meeting = entity.Meeting;
            DateFrom = entity.DateFrom;
            DateTo = entity.DateTo;
            Floors = entity.Floors;
        }

    }
}