using System;
using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Request;
using MongoDB.Bson;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class CreateAdmissionCommand : ICommand
    {
        public string Id { get; private set; }

        public string Description { get; private set; }

        public string Meeting { get; private set; }

        public DateTime DateFrom { get; private set; }

        public DateTime DateTo { get; private set; }

        public IEnumerable<int> Floors { get; private set; }

        public string VisitorId { get; private set; }

        public CreateAdmissionCommand(CreateAdmissionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Не переданы данные для создания");

            Id = ObjectId.GenerateNewId().ToString();
            Description = request.Description;
            Meeting = request.Meeting;
            DateFrom = request.DateFrom;
            Floors = request.Floors;
            VisitorId = request.VisitorId;
        }

        public CreateAdmissionCommand(CreateVisitorCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Не переданы данные для создания");

            Id = ObjectId.GenerateNewId().ToString();
            Description = cmd.Description;
            Meeting = cmd.Meeting;
            DateFrom = cmd.DateFrom;
            DateTo = cmd.DateTo;
            Floors = cmd.Floors;
            VisitorId = cmd.Id;
        }
    }
}