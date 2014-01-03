using System;
using System.Net.Http;
using System.Web.Http;
using Portfolio.API.Models;

namespace Portfolio.API.Controllers
{    
    public class ServerInfoController : ApiController
    {
        public ApiResult<GetServerInfoResult> Get(HttpRequestMessage message)
        {
            var data = new GetServerInfoResult
            {
                MachineName = Environment.MachineName,
                OperatingSystem = Environment.OSVersion.Platform.ToString(),
                Version = Environment.Version.ToString()
            };
            var result = new ApiResult<GetServerInfoResult>(data);
            return result;
        }
    }
}
