using System.Collections.Generic;
using System.Threading.Tasks;
using EQR.BackOffice.DataContracts.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EQR.BackOffice.DAL.Repositories
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private readonly IMongoDatabase _db;

        public VisitorsRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task Create(Visitor admission)
        {
            await _db.GetCollection<Visitor>("visitors").InsertOneAsync(admission);
        }

        public async Task Update(Visitor visitor)
        {
            var update = Builders<Visitor>.Update
                .Set(x => x.FirstName, visitor.FirstName)
                .Set(x => x.LastName, visitor.LastName)
                .Set(x => x.MiddleName, visitor.MiddleName);
            await _db.GetCollection<Visitor>("visitors").FindOneAndUpdateAsync(x => x.Id == visitor.Id, update);
        }

        public async Task Delete(ObjectId id)
        {
            await _db.GetCollection<Visitor>("visitors").DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Visitor>> GetAll()
        {
            return await _db.GetCollection<Visitor>("visitors").Find(x=> true).ToListAsync();
        }

        public async Task<Visitor> GetById(ObjectId id)
        {
            return await _db.GetCollection<Visitor>("visitors").Find(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}