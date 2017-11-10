using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DataContracts.Cqrs;
using EQR.BackOffice.DataContracts.Responses;

namespace EQR.BackOffice.Bll.Utils
{
    public sealed class BllInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICommandHandler<CreateAdmissionCommand>, AdmissionHandler>().Named("createadmission").LifestyleSingleton(),
                Component.For<IQueryHandler<GetAdmissionQuery, AdmissionResponse>, AdmissionHandler>().Named("getadmission").LifestyleSingleton()
            );
        }
    }
}