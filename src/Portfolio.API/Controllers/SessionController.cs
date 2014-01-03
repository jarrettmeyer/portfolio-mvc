using System;
using System.Diagnostics.Contracts;
using System.Web.Http;
using Portfolio.API.Models;
using Portfolio.Lib;
using Portfolio.Lib.Commands;

namespace Portfolio.API.Controllers
{
    public class SessionController : ApiController
    {
        private readonly IMediator mediator;

        public SessionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ApiResult<PostSessionResult> Post(PostSessionRequest model)
        {
            Contract.Requires<ArgumentNullException>(model != null);

            LogonCommand command = model.ToLogonCommand();
            LogonResult logonResult = mediator.Send(command);
            var apiResult = new ApiResult<PostSessionResult>();
            
            apiResult.IsSuccessful = logonResult.IsSuccessful;
            if (logonResult.IsSuccessful)
            {
                apiResult.Data.Id = logonResult.User.Id;
                apiResult.Data.SessionId = "";
                apiResult.Data.Username = logonResult.User.Username;
            }
            else
            {
                apiResult.AddError(new ErrorDef("Invalid credentials."));
            }
            
            return apiResult;
        }
    }
}
