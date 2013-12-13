using System.Net.Http;
using System.Web.Http;
using Portfolio.API.Results;
using Portfolio.Lib.ViewModels;

namespace Portfolio.API.Controllers
{
    public class SessionController : ApiController
    {
        public ApiResult<GetSession> Get(HttpRequestMessage message)
        {
            var cookies = message.Headers.GetCookies();
            var result = new ApiResult<GetSession>();
            result.IsSuccessful = false;
            return result;
        }

        public ApiResult<PostSession> Post(Credentials credentials)
        {
            var result = new ApiResult<PostSession>();
            return result;
        }
    }
}
