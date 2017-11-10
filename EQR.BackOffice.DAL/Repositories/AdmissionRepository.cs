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
            await _db.GetCollection<Admission>("admission").InsertOneAsync(admission);
        }

        public async Task<Admission> Get(ObjectId id)
        {
            return await _db.GetCollection<Admission>("admission").Find(x=>x.Id == id).SingleOrDefaultAsync();
        }
    }
}