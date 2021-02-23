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

        IEnumerable<WishlistModel> GetAllBookItems();

        string DeleteBooksFromWishlist(int wishlistId);
    }
}
