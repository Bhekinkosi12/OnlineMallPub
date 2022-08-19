using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMall.Models.Users;
using OnlineMall.Services.AuthService;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using OnlineMall.LocalDB;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;


namespace OnlineMall.FirebaseDB.Auth
{
    internal class AuthService : IAuthService
    {
        FirebaseAuthProvider _auth;
        FirebaseClient _client;
        private static UserM user;
        private static bool isAdmin;
        private string token;
        ICookie _cookie;

        private AuthenticationStateProvider _provider;
        public AuthService(ICookie cookie, AuthenticationStateProvider authProvider)
        {
            _provider = authProvider;
            _cookie = cookie;
            _auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyADB3AtQ4iAxfsn7S2pIb5XqEKvjnZONuM"));
            _client = new FirebaseClient("https://mzansigomall-default-rtdb.firebaseio.com");
        }

        public UserM? User { get => user; set => user = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public string? Token => token;

        public async Task<bool> AutoLogin()
        {
            try
            {

               var Retoken = await _cookie.GetValue("user");
                if (!string.IsNullOrEmpty(Retoken))
                {
                    FirebaseAuth firebaseAuth = new FirebaseAuth()
                    {
                         RefreshToken = Retoken
                    };
                    var res = await _auth.RefreshAuthAsync(firebaseAuth);
                    if(res != null)
                    {
                        
                        var itemResp = (await _client.Child("user").OnceAsync<UserM>()).FirstOrDefault(x => x.Object.Email == res.User.Email);

                        if (itemResp != null)
                        {
                            User = itemResp.Object;
                            
                        }
                        else
                        {
                            return false;
                        }

                        await _cookie.SetValue("user", res.RefreshToken, 1);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var response = await _auth.SignInWithEmailAndPasswordAsync(email, password);

                if(response != null)
                {


                    var itemResp = (await _client.Child("user").OnceAsync<UserM>()).FirstOrDefault(x => x.Object.Email == email);

                    if(itemResp != null)
                    {
                        User = itemResp.Object;
                    }


                    await _cookie.SetValue("user", response.RefreshToken, 1);
                }
                else
                {
                    return false;
                }


                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Signin(string email, string password,string username, string role = "User")
        {
            try
            {
                var response = await _auth.CreateUserWithEmailAndPasswordAsync(email, password,username,true);

                if(response != null)
                {

                    
                    UserM user = new UserM()
                    {
                         Email = email,
                          Name = username,
                           Token = response.RefreshToken,
                            Role = role
                    };

                    var itemResp = await _client.Child("user").PostAsync(user);

                    if(itemResp != null)
                    {
                        user.Token = "";
                        User = user;
                    }
                   

                   await _cookie.SetValue("user", response.RefreshToken, 1);
                    
                }
                else
                {
                    return false;
                }

                return await Task.FromResult(true);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpDateUser(UserM user)
        {
            try
            {
                var itemResp = (await _client.Child("user").OnceAsync<UserM>()).FirstOrDefault(x => x.Object.Id == user.Id);

                if(itemResp != null)
                {
                    await _client.Child("user").Child(itemResp.Key).PutAsync(user);
                }
                else
                {
                    return false;
                }


                return true;

            }
            catch
            {
                return false;
            }
        }

        
    }
}
