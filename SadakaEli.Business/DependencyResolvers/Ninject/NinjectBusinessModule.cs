using Ninject.Modules;
using SadakaEli.Business.AbstractStructure;
using SadakaEli.Business.Concrete;
using SadakaEli.DataAccess.AbstractStructure;
using SadakaEli.DataAccess.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule :NinjectModule
    {
        public override void Load()
        {
            Bind<IUserBs>().To<UserBs>();
            Bind<IUserRepository>().To<EfUserRepository>();
            
            Bind<IRoleBs>().To<RoleBs>();
            Bind<IRoleRepository>().To<EfRoleRepository>();

            Bind<IAdminBs>().To<AdminBs>();
            Bind<IAdminRepository>().To<EfAdminRepository>();

            Bind<INewsBs>().To<NewsBs>();
            Bind<INewsRepository>().To<EfNewsRepository>();

            Bind<ISliderBs>().To<SliderBs>();
            Bind<ISliderRepository>().To<EfSliderRepository>();



        }
    }
}
