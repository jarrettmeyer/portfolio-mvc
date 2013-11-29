using Portfolio.Models;

namespace Portfolio.Lib
{
    public static class IHttpSessionAdapterExtensions
    {
        public static void SetUpSession(this IHttpSessionAdapter sessionAdapter, User user)
        {
            sessionAdapter.CreatedAt = Clock.Instance.Now;
            sessionAdapter.IsAuthenticated = user.IsAuthenticated;
            sessionAdapter.Username = user.Username;
        }
    }
}