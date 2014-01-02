using System.Web.Http;
using Portfolio.API.Results;
using Portfolio.Lib;
using Portfolio.Lib.Queries;

namespace Portfolio.API.Controllers
{
    public class TagsController : ApiController
    {
        private readonly IMediator mediator;

        public TagsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public ApiResult<GetTags> Get()
        {
            var tags = mediator.Request(new TagsQuery());
            var data = new GetTags(tags);
            return new ApiResult<GetTags>(data);
        }
    }
}
