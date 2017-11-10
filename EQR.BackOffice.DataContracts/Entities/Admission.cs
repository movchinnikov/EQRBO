using System;
using System.Collections.Generic;
using EQR.BackOffice.DataContracts.Cqrs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EQR.BackOffice.DataContracts.Entities
{
    public sealed class Admission
    {
        public ObjectId Id { get; private set; }

        [BsonElement("description")]
        public string Description { get; private set; }

        [BsonRequired, BsonElement("meeting")]
        public string Meeting { get; private set; }

        [BsonRequired, BsonElement("date_from")]
        public DateTime DateFrom { get; private set; }

        [BsonRequired, BsonElement("date_to")]
        public DateTime DateTo { get; private set; }

        [BsonRequired, BsonElement("floors")]
        public IEnumerable<int> Floors { get; private set; }

        [BsonIgnore]
        public ObjectId VisitorId { get; private set; }

        public Admission(CreateAdmissionCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            Id = new ObjectId(cmd.Id);
            Description = cmd.Description;
            Meeting = cmd.Meeting;
            DateFrom = cmd.DateFrom;
            DateTo = cmd.DateTo;
            Floors = cmd.Floors;
            VisitorId = new ObjectId(cmd.VisitorId);
        }

        public Admission(UpdateAdmissionCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd), "Команда не передана");

            Id = new ObjectId(cmd.AdmissionId);
            Description = cmd.Description;
            Meeting = cmd.Meeting;
            DateFrom = cmd.DateFrom;
            DateTo = cmd.DateTo;
            Floors = cmd.Floors;
            VisitorId = new ObjectId(cmd.VisitorId);
        }
    }
}