using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Portfolio.API.Results;

namespace Portfolio.API.Controllers
{
    public class SessionController : ApiController
    {
        public ApiResult<GetSession> Get(HttpRequestMessage message)
        {
            AuthenticationHeaderValue authentication  = message.Headers.Authorization;
            var result = new ApiResult<GetSession>();
            result.IsSuccessful = false;
            return result;
        }

        public ApiResult<PostSession> Post()
        {
            var result = new ApiResult<PostSession>();
            return result;
        }
    }
}
