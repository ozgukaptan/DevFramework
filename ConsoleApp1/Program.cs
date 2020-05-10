using DevFramework.Nort.DataAccess.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Entities.Concrete;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllProduct();
        }
        public static List<Product> GetAllProduct()
        {
            EfProductDal pDal = new EfProductDal();
            var pList = pDal.GetList();
            return pList;

        }
    }
}
