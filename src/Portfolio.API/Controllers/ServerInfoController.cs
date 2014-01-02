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
            var data = new GetServerInfo
            {
                MachineName = Environment.MachineName,
                OperatingSystem = Environment.OSVersion.Platform.ToString(),
                Version = Environment.Version.ToString()
            };
            var result = new ApiResult<GetServerInfo>(data);
            return result;
        }
    }
}
