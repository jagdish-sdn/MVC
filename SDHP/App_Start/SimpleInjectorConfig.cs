using SDHP.Repository;
using SDHP.Repository.Infrastructure;
using SDHP.Service;
using SDHP.Service.Abstract;
using SDHP.Service.Abstract.EntityMasters;
using SDHP.Service.Abstract.Patient;
using SDHP.Service.Abstract.Professional.CareCoOrdinator;
using SDHP.Service.Abstract.Professional.FamilyHistories;
using SDHP.Service.Patient;
using SDHP.Service.Service;
using SDHP.Service.Service.EntityMasters;
using SDHP.Service.Service.Professional.CareCoOrdinator;
using SDHP.Service.Service.Professional.FamilyHistories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SDHP.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new Container()));
        }
        public static void Initialize(HttpConfiguration config, Container container)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
        public static Container RegisterServices(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.Register(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>), Lifestyle.Scoped);
          
            container.Register<DbContext, ApplicationContext>(Lifestyle.Scoped);
            container.Register<IDbFactory, DbFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ICompanyServices, CompanyServices>(Lifestyle.Scoped);
            container.Register<IPatientService, PatientService>(Lifestyle.Scoped);
            container.Register<ICommonServices, CommonService>(Lifestyle.Scoped);
            container.Register<IProfessionalService, ProfessionalService>(Lifestyle.Scoped);
            container.Register<ICategoryServices, CategoryServices>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Register<IFamilyHistoryService, FamilyHistoryService>(Lifestyle.Scoped);
            container.Register<ICareCoordinatorService, CareCoordinatorService>(Lifestyle.Scoped);
            container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
            //    new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }

    }
}