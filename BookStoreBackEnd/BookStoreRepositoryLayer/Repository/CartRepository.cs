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
    public class CartRepository : ICartRepository
    {
        public IConfiguration Configuration { get; }
        private readonly BookStoreContext cartContext;
        public CartRepository(BookStoreContext cartContext)
        {
            this.cartContext = cartContext;
        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Adding Book" +e.Message</exception>

        public CartModel AddItems(CartModel addItem)
        {
            try
            {
                cartContext.CartTable.Add(addItem);
                var add = cartContext.SaveChanges();

                if (add > 0)
                {
                    return addItem;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Adding Book" + e.Message);
            }
        }

        /// <summary>
        /// Gets all book items.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Retriving Cart Items" + e.Message</exception>

        public IEnumerable<CartBookResponse> GetAllBookItems(int userId)
        {
            try
            {
                IEnumerable<CartModel> getresult = cartContext.CartTable.Where(e => e.UserId == userId).ToList();

                if (getresult != null)
                {
                    IEnumerable<CartBookResponse> result = GetAllCartBooks(userId);
                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Retriving Data" + e.Message);
            }
        }

        /// <summary>
        ///Join Query For Retrive Books
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        public IEnumerable<CartBookResponse> GetAllCartBooks(int userId)
        {
            List<CartBookResponse> getResult = new List<CartBookResponse>();
            var result = from BookModel in cartContext.BookTable
                         join CartModel in cartContext.CartTable
                         on BookModel.BookId equals CartModel.BookId

                         select new CartBookResponse()
                         {
                             BookId = BookModel.BookId,
                             BookName = BookModel.BookName,
                             AuthorName = BookModel.AuthorName,
                             PublisherName = BookModel.PublisherName,
                             PublishedYear = BookModel.PublishedYear,
                             BookPrice = BookModel.BookPrice,
                             BookCount=BookModel.BookCount,
                             BookImage=BookModel.BookImage,
                             CartId = CartModel.CartId,
                             UserId = CartModel.UserId
                         };

            foreach (var data in result)
            {
                if (data.UserId == userId)
                {
                    getResult.Add(data);
                }
            }
            return getResult;
        }

        /// <summary>
        /// Deletes the books from wishlist.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Retriving Data" + e.Message</exception>
        public string DeleteBooksFromCart(int cartId)
        {
            try
            {
                CartModel deleteResult = cartContext.CartTable.Find(cartId);
                if (deleteResult != null)
                {
                    cartContext.CartTable.Remove(deleteResult);
                    cartContext.SaveChangesAsync();
                    return "RecordDeleted";
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Removing Data" + e.Message);
            }
        }

    }

}
