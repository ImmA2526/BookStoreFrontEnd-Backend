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

        IEnumerable<WishlistModel> GetAllBookItems();

        string DeleteBooksFromWishlist(int bookId);
    }
}
