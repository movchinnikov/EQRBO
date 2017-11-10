using System;
using EQR.BackOffice.DataContracts.Entities;

namespace EQR.BackOffice.DataContracts.Responses
{
    public sealed class AdmissionResponse
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }
        
        public string PhoneNumber { get; private set; }

        public AdmissionResponse(Admission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Сущность не передана");

            Id = entity.Id.ToString();
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            MiddleName = entity.MiddleName;
            PhoneNumber = entity.PhoneNumber;
        }

    }
}