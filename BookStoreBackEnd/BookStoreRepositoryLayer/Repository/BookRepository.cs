using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStoreRepositoryLayer
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext bookContext;
        private readonly IConfiguration configuration;
        public BookRepository(BookStoreContext bookContext, IConfiguration configuration)
        {
            this.bookContext = bookContext;
            this.configuration = configuration;

        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Adding Book" +e.Message</exception>

        public BookModel AddBooks(BookModel book)
        {
            try
            {
                bookContext.BookTable.Add(book);
                var add = bookContext.SaveChanges();

                if (add > 0)
                {
                    return book;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Adding Book" + e.Message);
            }
        }

        /// <summary>
        /// Images the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>

        public string Image(IFormFile file, int bookId)
        {
            try
            {
                if (file == null)
                {
                    return null;
                }
                var stream = file.OpenReadStream();
                var name = file.FileName;
                Account account = new Account(configuration["Cloudinary:CloudName"], configuration["Cloudinary:APIKey"], configuration["Cloudinary:APISecret"]);
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(name, stream)
                };
                ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
                cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                var data = this.bookContext.BookTable.Where(t => t.BookId == bookId).FirstOrDefault();
                data.BookImage = uploadResult.Uri.ToString();
                var result = this.bookContext.SaveChanges();
                return data.BookImage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Gets all book.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Retriving Data" + e.Message</exception>

        public IEnumerable<BookModel> GetAllBook()
        {
            try
            {
                IEnumerable<BookModel> getresult = bookContext.BookTable.Where(e => e.BookId > 0).ToList();
                if (getresult != null)
                {
                    return getresult;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Retriving Book" + e.Message);
            }
        }

        /// <summary>
        /// Updates the books by adding.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Updating Customer Record" + e.Message</exception>

        public BookModel UpdateBooksByAdding(int bookCount, int bookId)
        {
            try
            {
                var book = this.bookContext.BookTable.Where<BookModel>(e => e.BookId == bookId).FirstOrDefault();

                if (book != null)
                {
                    book.BookCount = book.BookCount - bookCount;
                    bookContext.SaveChanges();
                    var bookResult = this.bookContext.BookTable.Where<BookModel>(e => e.BookId == bookId).FirstOrDefault();

                    return bookResult;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Updating Customer Record" + e.Message);
            }
        }

        /// <summary>
        /// Updates the books by deleting.
        /// </summary>
        /// <param name="bookCount">The book count.</param>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Updating Customer Record" + e.Message</exception>
        public BookModel UpdateBooksByDeleting(int bookCount, int bookId)
        {
            try
            {
                var book = this.bookContext.BookTable.Where<BookModel>(e => e.BookId == bookId).FirstOrDefault();

                if (book != null)
                {
                    book.BookCount = book.BookCount + bookCount;
                    bookContext.SaveChanges();
                    return book;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Updating Customer Record" + e.Message);
            }
        }
    }
}
