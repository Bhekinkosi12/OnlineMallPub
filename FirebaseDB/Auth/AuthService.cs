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
        private AuthStateService _authState;
        public AuthService(ICookie cookie, AuthenticationStateProvider authProvider, ProtectedSessionStorage sessionStorage)
        {
            _authState = new AuthStateService(sessionStorage);
            _provider = authProvider;
            _cookie = cookie;



            


            
            _auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyADB3AtQ4iAxfsn7S2pIb5XqEKvjnZONuM"));



            try
            {

            Init();
            }
            catch
            {
                _client = new FirebaseClient("https://mzansigomall-default-rtdb.firebaseio.com");
            }



        }


        async void Init()
        {
           var response = await InitOptions();

            _client = new FirebaseClient("https://mzansigomall-default-rtdb.firebaseio.com",response);
        }


       async Task<FirebaseOptions?> InitOptions()
        {
            FirebaseOptions? firebaseOptions = new FirebaseOptions();

            var response = await _authState.GetAuthenticationStateAsync();
            
            if(response != null)
            {
               var selected = response.User.Claims.FirstOrDefault(x => x.Type == "Authentication");
                if(selected != null)
                {
                    
                    firebaseOptions = new FirebaseOptions()
                    {
                         AsAccessToken = false, 
                          AuthTokenAsyncFactory = () => Task.FromResult(selected.Value)
                    };
                }
            }
            else
            {
                return null;
            }


            return await Task.FromResult(firebaseOptions);
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


                    UserM user = new UserM()
                    {
                        Email = email,
                        Token = response.FirebaseToken,
                        Role = "User"
                    };
                    await _authState.UpdateAuthState(user);



                    Init();
                   



                    var itemResp = (await _client.Child("user").OnceAsync<UserM>()).FirstOrDefault(x => x.Object.Email == email);

                    if(itemResp != null)
                    {
                        if(itemResp.Object.Role == null)
                        {
                            itemResp.Object.Role = "User";
                        }
                        UserM user_ = new UserM()
                        {
                            Email = email,
                            Name = itemResp.Object.Name,
                            Token = response.FirebaseToken,
                            Role = itemResp.Object.Role
                        };
                        await _authState.UpdateAuthState(user_);



                        User = itemResp.Object;
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

        public async Task<bool> Signin(string email, string password,string username, string role = "User", double budget = 0)
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
                           Token = response.FirebaseToken,
                            Role = role,
                             Credit = new Models.Users.Credits.CreditM() { Email = email, BudgetAverageAmount = budget}
                    };
                    await _authState.UpdateAuthState(user);

                    Init();


                    var itemResp = await _client.Child("user").PostAsync(user);

                    if(itemResp != null)
                    {
                       

                        user.Token = "";
                        User = user;
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
