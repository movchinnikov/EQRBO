using System;
using System.Collections.Generic;

namespace EQR.BackOffice.DataContracts.Request
{
    public sealed class CreateVisitorRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Meeting { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public IEnumerable<int> Floors { get; set; }
    }
}