using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Nort.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        ProductValidator()
        {
            RuleFor(p => p.CategoryID).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryID == 1);

            //Must içine bool donduren metod alabilir
            RuleFor(p => p.ProductName).Must(StartWitA);
        }

        private bool StartWitA(string arg)
        {
            
            return true;
            throw new NotImplementedException();
        }
    }
}
