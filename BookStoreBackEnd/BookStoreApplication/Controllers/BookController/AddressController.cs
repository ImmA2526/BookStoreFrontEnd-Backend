using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers.BookController
{

    [Route("api/[controller]")]
    [ApiController]

    public class AddressController : Controller
    {
        private readonly IAddressBusiness addressBusiness;
        private readonly IConfiguration configuration;

        public AddressController(IAddressBusiness addressBusiness, IConfiguration configuration)
        {
            this.addressBusiness = addressBusiness;
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets all item.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("getAllBookItems")]
        public IActionResult GetAllBookItems(int userId)
        {
            try
            {
                IEnumerable<AddressResponse> getResult = this.addressBusiness.GetAllBookItems(userId);
                    if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = " Data Retrive Successfully", Data = getResult });
                }

                else
                {
                    return this.NotFound(new { Status = false, Message = "Error Occur While Fetching Data" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

    }
}
