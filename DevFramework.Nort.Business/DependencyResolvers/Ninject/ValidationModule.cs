using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Business.ValidationRules.FluentValidation;
using DevFramework.Nort.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Nort.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
