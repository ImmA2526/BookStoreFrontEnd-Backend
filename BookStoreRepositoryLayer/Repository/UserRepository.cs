using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text;

namespace BookStoreRepositoryLayer
{
    public class UserRepository :IUserRepository
    {
        public IConfiguration Configuration { get; }
        private readonly BookStoreContext bookStoreContext;
        public UserRepository(BookStoreContext bookStoreContext)
        {
            this.bookStoreContext = bookStoreContext;
        }

        /// <summary>
        /// PAssword Encryption
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        public string PasswordEncryption(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encData_byte);
                return encodedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        /// <summary>
        /// Decription of Password
        /// </summary>
        /// <param name="encryptpwd"></param>
        /// <returns></returns>

        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public UserModel UserRegistration(UserModel model)
        {
            try
            {
                string password = model.Password;
                string encodePass = PasswordEncryption(password);
                model.Password = encodePass;
                bookStoreContext.UserTabel.Add(model);
                var result = bookStoreContext.SaveChanges();
                if (result > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }

        /// <summary>
        /// Users login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>

        public UserModel UserLogin(LoginModel login)
        {
            try
            {
                var result = bookStoreContext.UserTabel.Where<UserModel>(x => x.Email == login.Email).FirstOrDefault();
                if (result != null)
                {
                    string decryptPass = Decryptdata(result.Password);
                    if (login.Password == decryptPass)
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Decrypting" + e.Message);
            }
        }

    }
}
