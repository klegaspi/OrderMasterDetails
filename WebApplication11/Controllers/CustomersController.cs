using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;

namespace WebApplication11.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerService _service = null;
        public CustomersController()
        {

        }

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(_service.GetAllCustomers());
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}