using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMall.Models.Users;

namespace OnlineMall.Services.AuthService
{
    internal interface IAuthService
    {
        UserM? User { get; set; }
        bool IsAdmin { get; set; } 
        string? Token { get; }
        Task<bool> AutoLogin();
        Task<bool> Login (string email, string password);
        Task<bool> Signin(string email, string password,string username, string role = "User");
        Task<bool> UpDateUser(UserM user)
        {
            throw new NotImplementedException();
        }
    }
}
