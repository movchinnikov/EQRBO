using System;
using System.Collections.Generic;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Request;
using MongoDB.Bson;

namespace EQR.BackOffice.DataContracts.Cqrs
{
    public sealed class UpdateVisitorCommand : ICommand
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public UpdateVisitorCommand(UpdateVisitorRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Не переданы данные для создания");

            Id = ObjectId.GenerateNewId().ToString();
            FirstName = request.FirstName;
            LastName = request.LastName;
            MiddleName = request.MiddleName;
        }
    }
}