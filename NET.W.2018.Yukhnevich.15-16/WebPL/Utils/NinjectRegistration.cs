using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.EF.Repositories;
using DAL.Interface.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPL.Utils
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<EFRepository>();
            Bind<IAccountNumberCreateService>().To<AccountNumberCreator>().InSingletonScope();
            Bind<IAccountService>().To<AccountService>().WithConstructorArgument(Kernel.GetBindings(typeof(IRepository)).First());
        }
    }
}