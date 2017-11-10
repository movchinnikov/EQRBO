using EQR.BackOffice.DataContracts.Entities;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace EQR.BackOffice.DAL.Repositories
{
    public interface IAdmissionRepository
    {
        Task Create(Admission admission);

        Task<Admission> Get(ObjectId id);
    }
}