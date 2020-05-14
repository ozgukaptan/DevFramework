using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Business.Abstract;
using DevFramework.Nort.Business.Concrete.Managers;
using DevFramework.Nort.Core.DataAccess;
using DevFramework.Nort.Core.DataAccess.EntityFramework;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.DataAccess.Concrete.EntityFramework;
using DevFramework.Nort.DataAccess.EntityFramework.Concrete;
using Ninject.Modules;

namespace DevFramework.Nort.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NortContext>();
        }
    }
}
