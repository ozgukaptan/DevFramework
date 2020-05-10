using DevFramework.Nort.Core.DataAccess.EntityFramework;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.DataAccess.Concrete.EntityFramework;
using DevFramework.Nort.Entities.ComplexType;
using DevFramework.Nort.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Nort.DataAccess.EntityFramework.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NortContext context = new NortContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.ProductID equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductID = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
            
        }
    }
}
