using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DevFramework.Nort.Business.Abstract;
using DevFramework.Nort.Business.ValidationRules.FluentValidation;
using DevFramework.Nort.Core.Aspects.Postsharp;
using DevFramework.Nort.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Nort.Core.Aspects.Postsharp.TransactionAspect;
using DevFramework.Nort.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Nort.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.DataAccess.EntityFramework.Concrete;
using DevFramework.Nort.Entities.Concrete;

namespace DevFramework.Nort.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {

            throw new NotImplementedException();
        }
        [CacheAspect(typeof(MemoryCacheManager))] 
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {


            _productDal.Add(product1);

            _productDal.Add(product2);


            //using (TransactionScope scope = new TransactionScope())
            //{
            //    try
            //    {
            //        _productDal.Add(product1);

            //        _productDal.Add(product2);

            //        scope.Complete();
            //    }
            //    catch
            //    {
            //        scope.Dispose();
            //    }
            //}


        }
    }

}
