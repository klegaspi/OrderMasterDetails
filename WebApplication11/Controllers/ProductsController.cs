using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication11.Controllers
{    
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService = null;
        
        public ProductsController()
        {            
        }

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());            
        }

        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult GetProductsByName(string productName)
        {
            return Ok(_productService.GetProductsByName(productName));
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(Product product)
        {
            if (product == null || !ModelState.IsValid)
                return BadRequest();

            _productService.AddProduct(product);

            return Ok();
        }

        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult Put(Product product)
        {
            if (product == null || !ModelState.IsValid)
                return BadRequest();

            _productService.EditProduct(product);

            return Ok();
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int productId)
        {
            _productService.DeleteProduct(productId);

            return Ok();
        }
    }
}