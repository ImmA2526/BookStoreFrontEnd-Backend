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
    public class WishListRepository : IWishListRepository
    {
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
        /// Gets all wishlist books.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns></returns>
        public IEnumerable<WishBookResponse> GetAllBookFromWishList(int userID)
        {
            List<WishBookResponse> getResult = new List<WishBookResponse>();
            var result = from BookModel in wishContext.BookTable
                         join WishlistModel in wishContext.WishlistTable
                         on BookModel.BookId equals WishlistModel.BookId

                         select new WishBookResponse()
                         {
                             BookId = BookModel.BookId,
                             BookName = BookModel.BookName,
                             AuthorName = BookModel.AuthorName,
                             BookPrice = BookModel.BookPrice,
                             BookCount = BookModel.BookCount,
                             BookImage = BookModel.BookImage,
                             BookDescription = BookModel.BookDescription,

                             WishId = WishlistModel.WishId,
                             UserId = WishlistModel.UserId
                         };

            foreach (var data in result)
            {
                if (data.UserId == userID)
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
        public string DeleteBooksFromWishlist(int wishlistId)
        {
            try
            {
                WishlistModel deleteResult = wishContext.WishlistTable.Find(wishlistId);
                if (deleteResult != null)
                {
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
