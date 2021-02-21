using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer.BooksModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers.BooksController
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController :Controller
    {
        private readonly IBookBusiness bookBusiness;
        private readonly IConfiguration configuration;

        public BooksController(IBookBusiness bookBusiness, IConfiguration configuration)
        {
            this.bookBusiness = bookBusiness;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("addBooks")]
        public IActionResult AddBooks([FromBody] BookModel book)
        {
            try
            {
                var result = this.bookBusiness.AddBooks(book);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Books Added Succesfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Adding Books", Data = result });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
                
            }
        }

    }
}
