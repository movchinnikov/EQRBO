using System.Collections.Generic;
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
                Component.For<ICommandHandler<DeleteAdmissionCommand>, AdmissionHandler>().Named("deleteadmission").LifestyleSingleton(),
                Component.For<ICommandHandler<UpdateAdmissionCommand>, AdmissionHandler>().Named("updateadmission").LifestyleSingleton(),
                Component.For<IAfterCommandHandler<CreateAdmissionCommand>, SmsService>().LifestyleSingleton(),
                Component.For<IQueryHandler<GetAdmissionQuery, AdmissionResponse>, AdmissionHandler>().Named("getadmission").LifestyleSingleton(),
                Component.For<IQueryHandler<GetAdmissionsQuery, IEnumerable<AdmissionResponse>>, AdmissionHandler>().Named("getadmissions").LifestyleSingleton(),

                Component.For<ICommandHandler<CreateVisitorCommand>, VisitorHandler>().Named("createvisitor").LifestyleSingleton(),
                Component.For<IAfterCommandHandler<CreateVisitorCommand>, VisitorHandler>().Named("aftercreatevisitor").LifestyleSingleton(),
                Component.For<ICommandHandler<UpdateVisitorCommand>, VisitorHandler>().Named("updatevisitor").LifestyleSingleton(),
                Component.For<ICommandHandler<DeleteVisitorCommand>, VisitorHandler>().Named("deletevisitor").LifestyleSingleton(),
                Component.For<IQueryHandler<GetVisitorsQuery, IEnumerable<VisitorResponse>>, VisitorHandler>().Named("getvisitors").LifestyleSingleton(),
                Component.For<IQueryHandler<GetVisitorQuery, VisitorResponse>, VisitorHandler>().Named("getvisitor").LifestyleSingleton()
            );
        }
    }
}