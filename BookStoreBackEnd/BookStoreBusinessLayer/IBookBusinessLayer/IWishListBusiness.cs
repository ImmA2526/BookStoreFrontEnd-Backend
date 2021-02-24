using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface IWishListBusiness
    {
        WishlistModel AddItems(WishlistModel addItem);

        IEnumerable<WishBookResponse> GetAllBookItems(int userID);

        string DeleteBooksFromWishlist(int wishListId);
    }
}
