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
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartBusiness cartBusinsess;

        public CartController(ICartBusiness cartBusinsess)
        {
            this.cartBusinsess = cartBusinsess;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("addBooks")]
        public IActionResult AddItems([FromBody] CartModel addItem)
        {
            try
            {
                var result = this.cartBusinsess.AddItems(addItem);
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
        [Route("getAllBooks")]
        public IActionResult GetAllBookFromCart(int userId)
        {
            try
            {
                IEnumerable<CartBookResponse> getResult = this.cartBusinsess.GetAllCartBooks(userId);
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Data Retrive Successfully", Data = getResult });
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
        [Route("deleteBooks")]
        public IActionResult DeleteBookFromWishlist(int cartId)
        {
            try
            {
                var delete = this.cartBusinsess.DeleteBooksFromCart(cartId);
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

        /// <summary>
        /// Updates the book by identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateBookById")]
        public IActionResult UpdateCart(CartModel model)
        {
            try
            {
                var update = this.cartBusinsess.UpdateCart(model);
                if (update != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Updated Succesfully", Data = update });
                }
                else
                {
                    return this.NotFound(new { Status = false, Message = "Error While Updating" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }

        /// <summary>
        /// Gets the cart books count.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        [HttpGet]
        [Route("getCounts")]
        public IActionResult  GetCartBooksCount(int userId)
        {
            try
            {
                var count = this.cartBusinsess.GetCartBooksCount(userId);
                if (count >0)
                {
                    return this.Ok(new { Status = true, Message = "The No of Books Are :" + count, Data = count });
                }
                else
                {
                    return this.NotFound(new { Status = false, Message = "Error While Updating" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });

            }
        }

    }
}
