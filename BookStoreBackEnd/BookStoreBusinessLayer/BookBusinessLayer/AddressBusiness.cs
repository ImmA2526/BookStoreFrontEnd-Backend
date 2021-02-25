using BookStoreBusinessLayer.IBookBusinessLayer;
using BookStoreModelLayer;
using BookStoreModelLayer.CustomerModels;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BookBusinessLayer
{
    public class AddressBusiness : IAddressBusiness
    {
        IAddressRepository addressRepo;

        public AddressBusiness(IAddressRepository addressRepo)
        {
            this.addressRepo = addressRepo;
        }

        public CustomerModel AddAddress(CustomerModel addAddress)
        {
            var getResult = addressRepo.AddAddress(addAddress);
            return getResult;
        }

        public CustomerModel UpdateAddress(CustomerModel update)
        {
            var updateResult = addressRepo.UpdateAddress(update);
            return updateResult;
        }

    }
}
