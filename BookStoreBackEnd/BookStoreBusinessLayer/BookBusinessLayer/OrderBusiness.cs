using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BookBusinessLayer
{
    public class OrderBusiness :IOrderBusiness
    {
        IOrderRepository orderRepo;

        public OrderBusiness(IOrderRepository orderRepo)
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
