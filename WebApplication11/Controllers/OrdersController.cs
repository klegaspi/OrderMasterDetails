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
    public class OrdersController : ApiController
    {
        private readonly IOrderService _service = null;
        public OrdersController()
        {

        }

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetAllOrders()
        {
            return Ok(_service.GetAllOrders());
        }

        [HttpGet]
        // GET api/<controller>/5
        public IHttpActionResult Get(int customerID)
        {
            
            return Ok(_service.GetOrdersByCustomerID(customerID));
        }

        [HttpGet]
        public IHttpActionResult Action(int orderID)
        {
            return Ok(_service.GetOrdersByID(orderID));
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult AddOrder(Order order)
        {
            if (order != null && ModelState.IsValid)
            {
                _service.AddOrder(order);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        // PUT api/<controller>/5
        public IHttpActionResult EditOrder(Order order)
        {
            if (order != null && ModelState.IsValid)
            {
                _service.EditOrder(order);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        // DELETE api/<controller>/5
        public IHttpActionResult DeleteOrder(int orderID)
        {
            _service.DeleteOrder(orderID);
            return Ok();
        }
    }
}