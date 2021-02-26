using BookStoreModelLayer;
using BookStoreModelLayer.CustomerModels;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreRepositoryLayer.Repository
{
    public class AddressRepository : IAddressRepository
    {

        private readonly BookStoreContext addressContext;
        public AddressRepository(BookStoreContext addressContext)
        {
            this.addressContext = addressContext;
        }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="addAddress">The add address.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Adding Customer Address" + e.Message</exception>

        public CustomerModel AddAddress(CustomerModel addAddress)
        {
            try
            {
                addressContext.CustomerTable.Add(addAddress);
                var add = addressContext.SaveChanges();

                if (add > 0)
                {
                    return addAddress;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Adding Customer Address" + e.Message);
            }
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="update">The update.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Error While Updating Record" + e.Message</exception>

        public CustomerModel UpdateAddress(CustomerModel update)
        {
            try
            {
                //var update = cartContext.CartTable.FirstOrDefault(book => book.CartId == model.CartId);
                if (update.UserId>0)
                {
                    addressContext.Entry(update).State = EntityState.Modified;
                    addressContext.SaveChanges();
                    return update;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error While Updating Customer Record" + e.Message);
            }
        }

       /// <summary>
        ///Join Query For Retrive Books
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        public AddressResponse GetAddress(int userId)
        {
            var result = from CustomerModel in addressContext.CustomerTable
                         join AddressTypeModel in addressContext.AddressTypeTable
                         on CustomerModel.AddressTypeId equals  AddressTypeModel.AddressTypeId  

                         select new AddressResponse()
                         {
                             CustomerId = CustomerModel.CustomerId,
                             FullName = CustomerModel.FullName,
                             PhoneNumber = CustomerModel.PhoneNumber,
                             PinCode = CustomerModel.PinCode,
                             Locality = CustomerModel.Locality,
                             City = CustomerModel.City,
                             Address = CustomerModel.Address,
                             AddressType = AddressTypeModel.AddressType,

                             UserId = CustomerModel.UserId,
                         };

            foreach (var data in result)
            {
                if (data.UserId == userId)
                {
                    return data;
                }
            }
            return null;
        }

    }
}
