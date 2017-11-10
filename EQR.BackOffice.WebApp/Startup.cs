using System;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using EQR.BackOffice.Bll.Utils;
using EQR.BackOffice.CQRS.Core;
using EQR.BackOffice.DAL.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EQR.BackOffice.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var container = new WindsorContainer();
            container.AddFacility<FactorySupportFacility>();
            container.Install(new BllInstaller(), new DalInstaller());
            container.Register(
                Component.For<ICqrsDispatcher, CqrsDispatcher>().LifestyleSingleton()
            );

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
