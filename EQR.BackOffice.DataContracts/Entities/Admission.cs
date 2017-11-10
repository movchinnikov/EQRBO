using System;
using EQR.BackOffice.DataContracts.Cqrs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EQR.BackOffice.DataContracts.Entities
{
    public sealed class Admission
    {
        public ObjectId Id { get; set; }

        [BsonRequired, BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonRequired, BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("middle_name")]
        public string MiddleName { get; set; }

        [BsonRequired, BsonElement("phone_number")]
        public string PhoneNumber { get; set; }

        public Admission(CreateAdmissionCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            Id = new ObjectId(cmd.Id);
            FirstName = cmd.FirstName;
            LastName = cmd.LastName;
            MiddleName = cmd.MiddleName;
            PhoneNumber = cmd.PhoneNumber;
        }
    }
}