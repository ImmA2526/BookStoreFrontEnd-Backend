using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WishListController : Controller
    {
        private readonly IWishListBusiness wishBusinsess;
        private readonly IConfiguration configuration;

        public WishListController(IWishListBusiness wishBusinsess, IConfiguration configuration)
        {
            this.wishBusinsess = wishBusinsess;
            this.configuration = configuration;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("addItems")]
        public IActionResult AddItems([FromBody] WishlistModel addItem)
        {
            try
            {
                var result = this.wishBusinsess.AddItems(addItem);
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

        /// <summary>
        /// Gets all item.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("getAllBookItems")]
        public IActionResult GetAllBookItems()
        {
            try
            {
                IEnumerable<WishlistModel> getResult = this.wishBusinsess.GetAllBookItems();
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Data Retrive Successfully",Data=getResult });
                }
                else
                {
                    return this.NotFound(new { Status = false, Message = "Error Occur While Fetching Cart Items" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Deletes the book from wishlist.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>

        [HttpDelete]
        [Route("deleteBookItems")]
        public IActionResult DeleteBookFromWishlist(int wishListId)
        {
            try
            {
                var delete = this.wishBusinsess.DeleteBooksFromWishlist(wishListId);
                if (delete != null)
                {
                    return this.Ok(new { Status = true, Message = "Item Removed SuccesFully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Removing" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

    }
}
