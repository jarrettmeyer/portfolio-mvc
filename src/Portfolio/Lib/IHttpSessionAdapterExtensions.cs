using Portfolio.Lib.Models;

namespace Portfolio.Lib
{
    public static class IHttpSessionAdapterExtensions
    {
        public static void SetUpSession(this IHttpSessionAdapter sessionAdapter, User user)
        {
            sessionAdapter.CreatedAt = Clock.Instance.Now;
            sessionAdapter.IsAuthenticated = user.Identity.IsAuthenticated;
            sessionAdapter.Username = user.Username;
        }
    }
}