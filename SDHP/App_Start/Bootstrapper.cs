using SDHP.Mapping;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SDHP.App_Start
{
    public class Bootstrapper
    {
    public static void Run()
    {
        SimpleInjectorConfig.Initialize(GlobalConfiguration.Configuration);
        AutoMapperConfiguration.Configure();
           
        }

}
}