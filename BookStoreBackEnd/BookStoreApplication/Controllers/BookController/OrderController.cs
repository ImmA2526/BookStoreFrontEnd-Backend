using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : Controller
    {
        private readonly IOrderBusiness orderBusinsess;

        public OrderController(IOrderBusiness orderBusinsess)
        {
            this.orderBusinsess = orderBusinsess;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("addItems")]
        public IActionResult OrderSummary([FromBody] OrderModel order)
        {
            try
            {
                var result = this.orderBusinsess.CreateOrderSummary(order);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Data Added Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Data is Not Added Succesfully " });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
