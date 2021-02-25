using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer.BooksModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BookBusinessLayer
{
    public class OrderBusiness :IOrderBusiness
    {
        IOrderBusiness orderRepo;

        public OrderBusiness(IOrderBusiness orderRepo)
        {
            this.orderRepo = orderRepo;
        }


        public int CreateOrderSummary(OrderModel orders)
        {
            var orderSummary = orderRepo.CreateOrderSummary(orders);
            return orderSummary;
        }
        
    }
}
