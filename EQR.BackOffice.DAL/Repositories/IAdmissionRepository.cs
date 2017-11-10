using System.Collections.Generic;
using EQR.BackOffice.DataContracts.Entities;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace EQR.BackOffice.DAL.Repositories
{
    public interface IAdmissionRepository
    {
        Task Create(Admission admission);

        Task Delete(ObjectId visitorId, ObjectId admissionId);

        Task Update(Admission admission);

        Task<Admission> Get(ObjectId visitorId, ObjectId admissionId);

        Task<IEnumerable<Admission>> GetAllByVisitor(ObjectId visitorId);

    }
}