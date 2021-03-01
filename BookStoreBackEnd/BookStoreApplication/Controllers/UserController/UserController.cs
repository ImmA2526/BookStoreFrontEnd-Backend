using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]

    public class UserController : Controller
    {
        private readonly IUserBusiness business;
        private readonly IConfiguration configuration;

        public UserController(IUserBusiness business, IConfiguration configuration)
        {
            this.business = business;
            this.configuration = configuration;
        }

        /// <summary>
        /// Genrates the JWT token.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        private string GenrateJWTToken(string Email)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("Email",Email)
            };
            var tokenOptionOne = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }

        /// <summary>
        /// Register User .
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>

        [HttpPost]
        //[Route("registerUser")]
        public IActionResult RegisterUser([FromBody] UserModel user)
        {
            try
            {
                var result = this.business.UserRegistration(user);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "User Data Added Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Data is Not Added Succesfully " });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Login the user.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns></returns>

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginUser([FromBody] LoginModel login)
        {
            try
            {

                var result = this.business.UserLogin(login);
                if (result != null)
                {
                    var token = GenrateJWTToken(result.Email);
                    return this.Ok(new { Status = true, Message = "Login Successfully", Data = token, id=result.UserId });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Login Failed" });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Forgot password.
        /// </summary>
        /// <param name="forgot">The forgot.</param>
        /// <returns></returns>
      
        [HttpGet]
        [Route("{email}")]
      
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = this.business.ForgotUserPassword(email);

                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Password Send Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Sending Password Failed" });
                }
            }

            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

        /// <summary>
        /// Reset password.
        /// </summary>
        /// <param name="reset">The reset.</param>
        /// <returns></returns>

        [HttpPut]
        //[Route("resetPassword")]
        public IActionResult ResetPassword(LoginModel reset)
        {
            try
            {
                var result = this.business.ResetUserPassword(reset);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Password Reset Succesfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Error While Reseting Password" });
                }
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }

    }
}
