using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrdersController(IOrderRepository _repository)
        {
            repository = _repository;
        }
        //[Authorize(Policy = "Approved")]
        [HttpGet(Name = "GetOrders")]
        public async Task<IActionResult> Get()
        {
            var query = this.HttpContext.Request.Query;
            if(query.ContainsKey("customer"))
            {
                if(query["customer"] != User.FindFirst("user_id").Value)
                {
                    return new BadRequestResult();
                }
                return new ObjectResult(await repository.GetOrdersByUserId(int.Parse(query["customer"])));
            }
            var result = await repository.GetOrders();
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "Approved")]
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await repository.GetOrder(id);
            if (User.FindFirst("role").Value == "customer")
            {
                if (User.FindFirst("user_id").Value != result.CustomerId.ToString())
                {
                    return new BadRequestResult();
                }
            }
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "Customer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var result = await repository.AddOrder(order);
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "LibrarianOrAdmin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Order order)
        {
            var result = await repository.UpdateOrder(order);
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "LibrarianOrAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repository.DeleteOrder(id);
            return new ObjectResult(result);
        }
    }
}
