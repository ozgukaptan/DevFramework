using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Business.Abstract;
using DevFramework.Nort.Business.ValidationRules.FluentValidation;
using DevFramework.Nort.Core.Aspects.Postsharp;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.DataAccess.EntityFramework.Concrete;
using DevFramework.Nort.Entities.Concrete;

namespace DevFramework.Nort.Business.Concrete.Managers
{
    public class ProductManager :  IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            
            throw new NotImplementedException();
        }
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }

    }

}
