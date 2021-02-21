using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
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
    public class BookRepository :IBookRepository
    {
        public IConfiguration Configuration { get; }
        private readonly BookStoreContext bookContext;
        public BookRepository(BookStoreContext bookContext)
        {
            this.bookContext = bookContext;
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
                throw new Exception("Error While Retriving Data" + e.Message);
            }
        }

    }

}
