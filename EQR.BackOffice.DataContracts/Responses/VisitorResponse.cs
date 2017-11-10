using System;
using System.Linq;
using EQR.BackOffice.DataContracts.Entities;

namespace EQR.BackOffice.DataContracts.Responses
{
    public sealed class VisitorResponse
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }

        public string PhoneNumber { get; private set; }

        public AdmissionResponse ActiveAdmission { get; private set; }

        public string AvatarUrl { get; private set; }


        public VisitorResponse(Visitor visitor)
        {
            if (visitor == null)
                throw new ArgumentNullException(nameof(visitor), "Не передана сущность");

            var admission = visitor.Admissions.FirstOrDefault();

            Id = visitor.Id.ToString();
            FirstName = visitor.FirstName;
            LastName = visitor.LastName;
            MiddleName = visitor.MiddleName;
            PhoneNumber = visitor.PhoneNumber;
            ActiveAdmission = admission != null ? new AdmissionResponse(admission) : null;
        }
    }
}