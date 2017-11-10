using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EQR.BackOffice.DAL.Repositories;
using MongoDB.Driver;

namespace EQR.BackOffice.DAL.Utils
{
    public sealed class DalInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var client = new MongoClient("mongodb://localhost:27017");

            container.Register(
                Component.For<IMongoClient>().UsingFactoryMethod(c => client).LifestyleSingleton(),
                Component.For<IMongoDatabase>().UsingFactoryMethod(c => client.GetDatabase("local")).LifestyleSingleton(),

                Component.For<IAdmissionRepository, AdmissionRepository>().LifestyleSingleton(),
                Component.For<IVisitorsRepository, VisitorsRepository>().LifestyleSingleton()
            );
        }
    }
}