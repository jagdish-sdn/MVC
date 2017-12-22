namespace SDHP.Repository.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI.WebControls;

    internal sealed partial class Configuration : DbMigrationsConfiguration<SDHP.Repository.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SDHP.Repository.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            #region [ City ]
            foreach (var city in City)
            {
                if (!context.CityLookup.Any(x => (x.CityName == city.CityName && x.DistrictID==city.DistrictID)))
                {
                    context.CityLookup.AddOrUpdate(city);
                }
            }
            #endregion
            #region [ District ]
            foreach (var District in District)
            {
                if (!context.DistrictLookup.Any(x => (x.DistrictName == District.DistrictName && x.StateID==District.StateID)))
                {
                    context.DistrictLookup.AddOrUpdate(District);
                }
            }
            #endregion
            #region [ States ]
            foreach (var State in States)
            {
                if (!context.StateLookup.Any(x => (x.StateName == State.StateName && x.CountryID == State.CountryID)))
                {
                    context.StateLookup.AddOrUpdate(State);
                }
            }
            #endregion
            #region [ Countries ]
            foreach (var Country in Counties)
            {
                if (!context.CountryLookup.Any(x => (x.CountryName == Country.CountryName)))
                {
                    context.CountryLookup.AddOrUpdate(Country);
                }
            }
            #endregion  

            
            #region [ Roles ]
            // long _MenuIndex = 1;
            if (!context.Roles.Any(r => r.Name == "Superadmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Superadmin" };

                manager.Create(role);
                /*  Create menus for Superadmin role.   */
                //foreach (Menu Data in _SuperadminMenus)
                //{
                //    if (!context.Menu.Any(x => (x.Name == Data.Name)))
                //    {
                //        Menu DBData = context.Menu.Add(Data);
                //        context.MenuMapUserRole.Add(new MenuMapUserRole()
                //        {
                //            MenuID = _MenuIndex,
                //            UserRoleID = role.Id
                //        });
                //    }
                //    _MenuIndex = _MenuIndex + 1;
                //}
                /****  Create menus for Superadmin role.   */
            }

            if (!context.Roles.Any(r => r.Name == "Companyadmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Companyadmin" };

                manager.Create(role);
                ///*  Create menus for companyadmin role.   */
                //foreach (Menu Data in _CompanyadminMenus)
                //{
                //    if (!context.Menu.Any(x => (x.Name == Data.Name)))
                //    {
                //        var DBData = context.Menu.Add(Data);
                //        context.MenuMapUserRole.Add(new MenuMapUserRole()
                //        {
                //            MenuID = _MenuIndex,
                //            UserRoleID = role.Id
                //        });
                //    }
                //    _MenuIndex = _MenuIndex + 1;
                //}
                /****  Create menus for companyadmin role.   */
            }
            if (!context.Roles.Any(r => r.Name == "Professional"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Professional" };

                manager.Create(role);
                /*  Create menus for employee role.   */
                //foreach (Menu Data in _EmployeeMenus)
                //{
                //    if (!context.Menu.Any(x => (x.Name == Data.Name)))
                //    {
                //        Menu DBData = context.Menu.Add(Data);
                //        context.MenuMapUserRole.Add(new MenuMapUserRole()
                //        {
                //            MenuID = _MenuIndex,
                //            UserRoleID = role.Id
                //        });
                //    }
                //    _MenuIndex = _MenuIndex + 1;
                //}
                /****  Create menus for employee role.   */
            }
            if (!context.Roles.Any(r => r.Name == "Patient"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Patient" };

                manager.Create(role);
                /*  Create menus for selfdirected role.   */
                //foreach (Menu Data in _SelfDirectedUserMenus)
                //{
                //    if (!context.Menu.Any(x => (x.Name == Data.Name)))
                //    {
                //        var DBData = context.Menu.Add(Data);
                //        context.MenuMapUserRole.Add(new MenuMapUserRole()
                //        {
                //            MenuID = _MenuIndex,
                //            UserRoleID = role.Id
                //        });
                //    }
                //    _MenuIndex = _MenuIndex + 1;
                //}
                /****  Create menus for selfdirected role.   */
            }
            #endregion
            #region [Default Users]
            if (!context.Users.Any(u => u.UserName == "patient@yopmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "patient@yopmail.com", Email = "patient@yopmail.com" };
                manager.Create(user, "Password@123");
                manager.AddToRole(user.Id, "Patient");
            }
            #endregion
        }
    }
}
