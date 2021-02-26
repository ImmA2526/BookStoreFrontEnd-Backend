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
        public IActionResult AddBooks(BookModel book)
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

        /// <summary>
        /// Books the image upload.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadImage/{bookId}")]
        public IActionResult BookImageUpload(IFormFile image, int bookId)
        {
            try
            {
                var book = this.bookbusiness.Image(image, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Image Uploaded Succesfully", Data = book });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Uploading Book Image" });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the book by adding.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateBook/addBookCount/{bookId}")]
        public IActionResult UpdateBookByAdding(int bookCount, int bookId)
        {
            try
            {
                var book = this.bookbusiness.UpdateBooksByAdding(bookCount, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Count Updated Succesfully", Data = book });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Updating Book Count" });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Updates the book by deleting.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>

        [HttpPut]
        [Route("updateBook/deleteBookCount/{bookId}")]
        public IActionResult UpdateBookByDeleting(int bookCount, int bookId)
        {
            try
            {

                var book = this.bookbusiness.UpdateBooksByDeleting(bookCount, bookId);
                if (book != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Count Updated Succesfully", Data = book });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Updating Book Count" });
                }

            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
    }
}
