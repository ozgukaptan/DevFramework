using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Business.Abstract;

using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.DataAccess.EntityFramework.Concrete;
using DevFramework.Nort.Entities.Concrete;

namespace DevFramework.Nort.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        ProductManager(EfProductDal productDal)
        {
            _productDal = productDal;
        }


        public Product Add(Product product)
        {
            return _productDal.Add(product);
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
