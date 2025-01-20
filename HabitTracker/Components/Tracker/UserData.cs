using Microsoft.AspNetCore.Components.Authorization;

namespace HabitTracker.Components.Tracker
{
    public static class UserData
    {
        public static async Task<Guid> GetCurrentUserGuid(AuthenticationStateProvider authenticationStateProvider)
        {
            AuthenticationState? authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var claim = user.FindFirst(u => u.Type.Contains("nameidentifier")) 
                ?? throw new Exception("No nameidentifier found for current user.");
            var userID = new Guid(claim.Value);
            return userID; 
        }
    }
}
