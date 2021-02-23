using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface IUserBusiness
    {
        UserModel UserRegistration(UserModel model);

        UserModel UserLogin(LoginModel login);

        string ForgotUserPassword(ForgotModel forgot);

        string ResetUserPassword(LoginModel reset);
    }
}
