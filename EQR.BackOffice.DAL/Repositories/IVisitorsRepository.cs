using System.Collections.Generic;
using System.Threading.Tasks;
using EQR.BackOffice.DataContracts.Entities;
using MongoDB.Bson;

namespace EQR.BackOffice.DAL.Repositories
{
    public interface IVisitorsRepository
    {
        Task Create(Visitor visitor);

        Task Update(Visitor visitor);

        Task Delete(ObjectId id);

        Task<IEnumerable<Visitor>> GetAll();

        Task<Visitor> GetById(ObjectId id);
    }
}