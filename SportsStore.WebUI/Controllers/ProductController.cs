using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        // GET: Product
        /*I added a constructor that declares a dependency on the
          IProductRepository interface, which will lead Ninject to inject the dependency for the product repository when
          it instantiates the controller class.*/
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List(int page = 1)
        {
            /*return View(repository.Products
                .OrderBy(p=>p.ProductID)
                .Skip((page-1)*PageSize)
                .Take(PageSize)
                );*/
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(model);
        }



    }
}
            
        
