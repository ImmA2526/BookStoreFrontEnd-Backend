using BookStoreModelLayer;
using BookStoreModelLayer.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBookBusinessLayer
{
    public interface IAddressBusiness
    {

         CustomerModel AddAddress(CustomerModel addAddress);

         CustomerModel UpdateAddress(CustomerModel update);

        AddressResponse GetAddress(int userId);
    }
}
