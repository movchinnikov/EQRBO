﻿using System;
using System.Collections.Generic;

namespace EQR.BackOffice.DataContracts.Request
{
    public sealed class CreateAdmissionRequest
    {
        public string VisitorId { get; set; }

        public string Description { get; set; }

        public string Meeting { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public IEnumerable<int> Floors { get; set; }
    }
}