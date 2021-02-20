using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IUserRepository
    {
        UserModel UserRegistration(UserModel model);

        UserModel UserLogin(LoginModel login);

        string ForgotUserPassword(ForgotModel forgot);

        string ResetUserPassword(LoginModel reset);
    }
}
