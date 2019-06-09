using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public int pageSize = 4;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        public ViewResult List(int productPage = 1) 
                => View(new ProductListViewModel {
                    Products = _repository.Products
                               .OrderBy(p => p.ProductID)
                               .Skip((productPage - 1) * pageSize)
                               .Take(pageSize),
                    PagingInfo = new PagingInfo {
                        CurrentPage = productPage,
                        ItemsPerPage = pageSize,
                        TotalItems = _repository.Products.Count()
                    }
                });
        
    }
}