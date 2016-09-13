using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;

namespace WebApplication11.Controllers
{
    public class ProductOptionsController : ApiController
    {
        private readonly IProductOptionService _productOptionService = null;

        public ProductOptionsController()
        {            
        }

        public ProductOptionsController(IProductOptionService productService)
        {
            _productOptionService = productService;
        }

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetAllProductOptions()
        {
            return Ok(_productOptionService.GetAllProductOptions());            
        }

        [HttpGet]
        public IHttpActionResult GetAllProductOptionsByProductID(int productID)
        {
            return Ok(_productOptionService.GetAllProductOptionsByProductID(productID));
        }

        [HttpGet]
        public IHttpActionResult GetProductsOptionsByName(string optionName)
        {
            return Ok(_productOptionService.GetProductsOptionsByName(optionName));
        }

        [HttpGet]
        public IHttpActionResult GetProductsOptionsByProductName(string productName)
        {
            return Ok(_productOptionService.GetProductsOptionsByProductName(productName));
        }

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(ProductOption productOption)
        {
            if (productOption == null || !ModelState.IsValid)
                return BadRequest();

            _productOptionService.AddProductOption(productOption);

            return Ok();
        }


        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(ProductOption productOption)
        {
            _productOptionService.EditProductOption(productOption);

            return Ok();
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int productOptionId)
        {
            _productOptionService.DeleteProductOption(productOptionId);

            return Ok();
        }
    }
}