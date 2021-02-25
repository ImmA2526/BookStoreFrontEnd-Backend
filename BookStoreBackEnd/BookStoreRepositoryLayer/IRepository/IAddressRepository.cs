using BookStoreModelLayer;
using BookStoreModelLayer.CustomerModels;
using BookStoreRepositoryLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IAddressRepository
    {

        CustomerModel AddAddress(CustomerModel addAddress);

       CustomerModel UpdateAddress(CustomerModel update);
    }

}
