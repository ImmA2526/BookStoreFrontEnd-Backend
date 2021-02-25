using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBookBusinessLayer
{
    public interface IOrderBusiness
    {
        int CreateOrderSummary(OrderModel orders);
    }
}
