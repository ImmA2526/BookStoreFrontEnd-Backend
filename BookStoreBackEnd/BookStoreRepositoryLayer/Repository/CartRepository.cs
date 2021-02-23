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
    public class CartRepository :ICartRepository
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

        public IEnumerable<CartModel> GetAllBookItems()
        {
            try
            {
                IEnumerable<CartModel> getresult = cartContext.CartTable.Where(e => e.CartId > 0).ToList();
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
                WishlistModel deleteResult = cartContext.WishlistTable.Find(cartId);
                if (deleteResult != null)
                {
                    //wishContext.WishlistTable.Remove();
                    cartContext.WishlistTable.Remove(deleteResult);
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
