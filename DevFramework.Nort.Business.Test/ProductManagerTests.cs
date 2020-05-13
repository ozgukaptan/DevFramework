using System;
using DevFramework.Nort.Business.Concrete.Managers;
using DevFramework.Nort.DataAccess.Abstract;
using DevFramework.Nort.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace DevFramework.Nort.Business.Test
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_Validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
            productManager.Update(new Product());
        }
    }
}
