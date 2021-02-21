using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookRepository : IBookRepository
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

    }

}
