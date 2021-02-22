using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class CartBusiness:ICartBusiness
    {
        ICartRepository cartRepo;

        public CartBusiness(ICartRepository cartRepo)
        {
            this.cartRepo = cartRepo;
        }

        public CartModel AddItems(CartModel addItem)
        {
            var result = cartRepo.AddItems(addItem);
            return result;
        }
    }
}
