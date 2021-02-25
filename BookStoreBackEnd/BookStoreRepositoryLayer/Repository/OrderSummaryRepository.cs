using BookStoreModelLayer.BooksModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class OrderSummaryRepository : IOrderRepository
    {
        private readonly BookStoreContext orderContext;
        public OrderSummaryRepository(BookStoreContext orderContext)
        {
            this.orderContext = orderContext;
        }


        /// <summary>
        /// Creates the order summary.
        /// </summary>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Adding Customer Address" + e.Message</exception>
        public int CreateOrderSummary(OrderModel orders)
        {
            try
            {
                Random randomOrder = new Random();
                orders.OrderSummaryID = randomOrder.Next(100000, 999999);
                orderContext.OrderSummaryTable.Add(orders);
                var add = orderContext.SaveChanges();
                return add;
            }

            catch (Exception e)
            {
                throw new Exception("Error While Adding Customer Address" + e.Message);
            }
        }
    }
}
