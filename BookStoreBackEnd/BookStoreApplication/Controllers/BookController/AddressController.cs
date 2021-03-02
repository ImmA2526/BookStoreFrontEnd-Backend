using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.CustomerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AddressController : Controller
    {
        private readonly IAddressBusiness addressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            this.addressBusiness = addressBusiness;

        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        [HttpPost]
        //[Route("addAddress")]
        public IActionResult AddAddress([FromBody] CustomerModel addAddress)
        {
            try
            {
                var result = this.addressBusiness.AddAddress(addAddress);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Address Data Added Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Error Occur While Adding Address Data " });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="updates">The updates.</param>
        /// <returns></returns>

        [HttpPut]
        //[Route("updateAddress")]
        public IActionResult UpdateAddress(CustomerModel updates)
        {
            try
            {
                var update = this.addressBusiness.UpdateAddress(updates);
                if (update != null)
                {
                    return this.Ok(new { Status = true, Message = "Address Updated Succesfully", Data = update });
                }
                return this.NotFound(new { Status = false, Message = "Error While Updating Address" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAddress(int userId)
        {
            try
            {
                var getAddress = this.addressBusiness.GetAddress(userId);
                if (getAddress != null)
                {
                    return this.Ok(new { Status = true, Message = "Address Data Retrive Succesfully", Data = getAddress });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Retriving Address Data" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

    }
}
