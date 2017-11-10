using System;
using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Request;
using MongoDB.Bson;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class CreateVisitorCommand : ICommand
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Meeting { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public IEnumerable<int> Floors { get; set; }

        public CreateVisitorCommand(CreateVisitorRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Не переданы данные для создания");

            Id = ObjectId.GenerateNewId().ToString();
            FirstName = request.FirstName;
            LastName = request.LastName;
            MiddleName = request.MiddleName;
            PhoneNumber = request.PhoneNumber;
            Description = request.Description;
            Meeting = request.Meeting;
            DateFrom = request.DateFrom;
            DateTo = request.DateTo;
            Floors = request.Floors;
        }
    }
}