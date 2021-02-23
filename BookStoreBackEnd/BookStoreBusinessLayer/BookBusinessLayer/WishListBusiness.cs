using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class WishListBusiness:IWishListBusiness
    {
        IWishListRepository wishRepo;

        public WishListBusiness(IWishListRepository wishRepo)
        {
            this.wishRepo = wishRepo;
        }

        public WishlistModel AddItems(WishlistModel addItem)
        {
            var result = wishRepo.AddItems(addItem);
            return result;
        }

        public IEnumerable<WishlistModel> GetAllBookItems()
        {
            var getResult = wishRepo.GetAllBookItems();
            return getResult;
        }

        public string DeleteBooksFromWishlist(int wishlistId)
        {
            var deleteResult = wishRepo.DeleteBooksFromWishlist(wishlistId);
            return deleteResult;
        }
    }
}
