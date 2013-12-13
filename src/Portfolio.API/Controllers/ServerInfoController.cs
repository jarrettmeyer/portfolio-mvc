using System;
using System.Net.Http;
using System.Web.Http;
using Portfolio.API.Results;

namespace Portfolio.API.Controllers
{
    [RoutePrefix("api/serverinfo")]
    public class ServerInfoController : ApiController
    {
        public ApiResult<GetServerInfo> Get(HttpRequestMessage message)
        {
            var result = new ApiResult<GetServerInfo>();
            result.IsSuccessful = true;
            result.Data.MachineName = Environment.MachineName;
            result.Data.OperatingSystem = Environment.OSVersion.Platform.ToString();
            result.Data.Version = Environment.Version.ToString();
            return result;
        }
    }
}
