using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using OnlineMall.Models.Users;

namespace OnlineMall.FirebaseDB.Auth
{
    public class AuthStateService : AuthenticationStateProvider
    {

        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymouse = new ClaimsPrincipal(new ClaimsIdentity());
        public AuthStateService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage; 
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {


                var userSessionResult = await _sessionStorage.GetAsync<UserM>("UserSession");

                var userSession = userSessionResult.Success ? userSessionResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymouse));
                }
                else
                {

                    var claimsPrinciple = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.Name),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }, "CustomAuth"));
                    return await Task.FromResult(new AuthenticationState(claimsPrinciple));
                }

            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymouse));
            }
        }

        public async Task UpdateAuthState(UserM? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if(userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name,userSession.Name),
                    new Claim(ClaimTypes.Role,userSession.Role)
                }));

            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymouse;
            }


            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
