using Microsoft.AspNetCore.Mvc;
using ProductsCRUDWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsCRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        public ProductsController()
        {
            productRepository = new ProductRepository();
        }


        //GET ALL
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return productRepository.GetAll();
        }


        [HttpGet("{id:int}")]
        public Products Get(int id)
        {
            return productRepository.GetOne(id);
        }

        [HttpPost]
        public void Post([FromBody] Products product)
        {
            if (ModelState.IsValid)
                productRepository.Insert(product);
        }

        [HttpPut("{id:int}")]
        public void Put(int id, [FromBody] Products product)
        {
            product.ProductId = id;
            if (ModelState.IsValid)
                productRepository.Update(product);
        }

        
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
