using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
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
        //[Route("addOrder")]
        public IActionResult OrderSummary([FromBody] OrderModel order)
        {
            try
            {
                var result = this.orderBusinsess.CreateOrderSummary(order);
                if (result > 0)
                {
                    return this.Ok(new { Status = true, Message = "Order Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Adding Order " });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
