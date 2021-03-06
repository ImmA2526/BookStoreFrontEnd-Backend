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
    //[Authorize]
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
        //[Route("addBooks")]
        public IActionResult AddItems([FromBody] CartModel addItem)
        {
            try
            {
                var result = this.cartBusinsess.AddItems(addItem);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Data Added in Cart Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Error While Adding Book Data in Cart" });
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
        [Route("{userId}")]
        public IActionResult GetAllBookFromCart(int userId)
        {
            try
            {
                IEnumerable<CartBookResponse> getResult = this.cartBusinsess.GetAllCartBooks(userId);
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Data Retrive Successfully", Data = getResult });
                }
                return this.NotFound(new { Status = false, Message = "Error Occur While Fetching Cart Data" });
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
        [Route("{cartId}")]
        public IActionResult DeleteBookFromWishlist(int cartId)
        {
            try
            {
                var delete = this.cartBusinsess.DeleteBooksFromCart(cartId);
                if (delete != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Item Removed SuccesFully" });
                }
                return this.NotFound(new { Status = false, Message = "Error While Removing Cart Items" });
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
        //[Route("{cartId}")]
        public IActionResult UpdateCart(CartModel model)
        {
            try
            {
                var update = this.cartBusinsess.UpdateCart(model);
                if (update != null)
                {
                    return this.Ok(new { Status = true, Message = "Cart Book Updated Succesfully", Data = update });
                }
                return this.NotFound(new { Status = false, Message = "Error While Updating Cart Item Count" });
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
        [Route("CartBookCount/{userId}")]
        public IActionResult GetCartBooksCount(int userId)
        {
            try
            {
                var count = this.cartBusinsess.GetCartBooksCount(userId);
                if (count > 0)
                {
                    return this.Ok(new { Status = true, Message = "The No of Books Are :" + count, Data = count });
                }
                return this.NotFound(new { Status = false, Message = "Error While Updating Book Count" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

    }
}
