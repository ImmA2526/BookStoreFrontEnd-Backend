using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IOrderRepository
    {
        int CreateOrderSummary(OrderModel orders);
    }
}
