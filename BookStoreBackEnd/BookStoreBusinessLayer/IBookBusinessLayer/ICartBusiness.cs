using BookStoreModelLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface ICartBusiness
    {
        CartModel AddItems(CartModel addItem);

        IEnumerable<CartBookResponse> GetAllBookItems(int userId);

        string DeleteBooksFromCart(int cartId);

        CartModel UpdateCart(CartModel model);
    }
}
