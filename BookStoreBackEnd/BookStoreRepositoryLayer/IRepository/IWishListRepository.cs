using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IWishListRepository
    {
        WishlistModel AddItems(WishlistModel addItem);

        IEnumerable<WishBookResponse> GetAllBookFromWishList(int userID);

        string DeleteBooksFromWishlist(int wishListId);
    }
}
