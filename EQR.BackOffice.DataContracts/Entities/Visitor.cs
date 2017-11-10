using System;
using System.Collections;
using EQR.BackOffice.DataContracts.Cqrs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace EQR.BackOffice.DataContracts.Entities
{
    public sealed class Visitor
    {
        public ObjectId Id { get; private set; }

        [BsonRequired, BsonElement("first_name")]
        public string FirstName { get; private set; }

        [BsonRequired, BsonElement("last_name")]
        public string LastName { get; private set; }

        [BsonElement("middle_name")]
        public string MiddleName { get; private set; }

        [BsonRequired, BsonElement("phone_number")]
        public string PhoneNumber { get; private set; }

        [BsonElement("admissions")]
        public ICollection<Admission> Admissions { get; private set; }

        public Visitor(CreateVisitorCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            Id = new ObjectId(cmd.Id);
            FirstName = cmd.FirstName;
            LastName = cmd.LastName;
            MiddleName = cmd.MiddleName;
            PhoneNumber = cmd.PhoneNumber;
            Admissions = new List<Admission>();
        }

        public Visitor(UpdateVisitorCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            Id = new ObjectId(cmd.Id);
            FirstName = cmd.FirstName;
            LastName = cmd.LastName;
            MiddleName = cmd.MiddleName;
        }
    }
}