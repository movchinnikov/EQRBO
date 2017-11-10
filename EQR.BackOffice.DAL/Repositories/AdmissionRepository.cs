using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EQR.BackOffice.DataContracts.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EQR.BackOffice.DAL.Repositories
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly IMongoDatabase _db;

        public AdmissionRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task Create(Admission admission)
        {
            var update = Builders<Visitor>.Update.Push<Admission>(e => e.Admissions, admission);
            await _db.GetCollection<Visitor>("visitors").FindOneAndUpdateAsync(x=>x.Id == admission.VisitorId, update);
        }

        public async Task Delete(ObjectId visitorId, ObjectId admissionId)
        {
            var update = Builders<Visitor>.Update.PullFilter(x => x.Admissions, x => x.Id == admissionId);
            await _db.GetCollection<Visitor>("visitors").FindOneAndUpdateAsync(x => x.Id == visitorId, update);
        }

        public async Task Update(Admission admission)
        {
            var filter = Builders<Visitor>.Filter.And(
                Builders<Visitor>.Filter.Where(x => x.Id == admission.VisitorId),
                Builders<Visitor>.Filter.ElemMatch(x => x.Admissions, x => x.Id == admission.Id));

            var update = Builders<Visitor>.Update
                .Set("admissions.$.date_from", admission.DateFrom)
                .Set("admissions.$.date_to", admission.DateTo)
                .Set("admissions.$.description", admission.Description)
                .Set("admissions.$.meeting", admission.Meeting)
                .Set("admissions.$.floors", admission.Floors);
            await _db.GetCollection<Visitor>("visitors").UpdateOneAsync(filter, update);
        }

        public async Task<Admission> Get(ObjectId visitorId, ObjectId admissionId)
        {
            var visitor = await _db.GetCollection<Visitor>("visitors").Find(x=> x.Id == visitorId).SingleOrDefaultAsync();
            Admission admission = null;
            if (visitor != null)
                admission = visitor.Admissions.FirstOrDefault(x => x.Id == admissionId);
            return admission;
        }

        public async Task<IEnumerable<Admission>> GetAllByVisitor(ObjectId visitorId)
        {
            var visitor = await _db.GetCollection<Visitor>("visitors").Find(x => x.Id == visitorId).SingleOrDefaultAsync();
            IEnumerable<Admission> admissions = null;
            if (visitor != null)
                admissions = visitor.Admissions;
            return admissions ?? new Admission[0];
        }
    }
}