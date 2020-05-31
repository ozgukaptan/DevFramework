using DevFramework.Nort.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Nort.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private  IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {

            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }
    }
}