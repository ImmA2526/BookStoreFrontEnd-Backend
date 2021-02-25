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

    public class BookController : Controller
    {
        private readonly IBookBusiness bookbusiness;
      
        public BookController(IBookBusiness bookbusiness)
        {
            this.bookbusiness = bookbusiness;
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("addBooks")]
        public IActionResult AddBooks([FromBody] BookModel book)
        {
            try
            {
                var result = this.bookbusiness.AddBooks(book);
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
        /// Gets all book.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("getAllRecord")]
        public IActionResult GetAllBook()
        {
            try
            {
                IEnumerable<BookModel> getResult = this.bookbusiness.GetAllBook();
                if (getResult != null)
                {
                    return this.Ok(new { Status = true, Message = "Data Retrived Succesfully", Data = getResult });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Fetching Data" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}
