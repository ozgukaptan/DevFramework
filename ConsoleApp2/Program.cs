using DevFramework.Nort.Business.Concrete.Managers;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.Entities.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product_Validation_check();
        }

        
        public static void Product_Validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
