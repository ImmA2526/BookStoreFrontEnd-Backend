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
    public class WishListRepository :IWishListRepository
    {
        public IConfiguration Configuration { get; }
        private readonly BookStoreContext wishContext;
        public WishListRepository(BookStoreContext wishContext)
        {
            this.wishContext = wishContext;
        }

        /// <summary>
        /// Adds the books.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Adding Book" +e.Message</exception>

        public WishlistModel AddItems(WishlistModel addItem)
        {
            try
            {
                wishContext.WishlistTable.Add(addItem);
                var add = wishContext.SaveChanges();

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

        public IEnumerable<WishlistModel> GetAllBookItems()
        {
            try
            {
                IEnumerable<WishlistModel> getresult = wishContext.WishlistTable.Where(e => e.WishlistID > 0).ToList();
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
        public string DeleteBooksFromWishlist(int wishlistId)
        {
            try
            {
                WishlistModel deleteResult = wishContext.WishlistTable.Find(wishlistId);
                if (deleteResult != null)
                {
                    //wishContext.WishlistTable.Remove();
                    wishContext.WishlistTable.Remove(deleteResult);
                    wishContext.SaveChangesAsync();
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
