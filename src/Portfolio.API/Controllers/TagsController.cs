using System.Web.Http;
using Portfolio.API.Models;
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

        public ApiResult<GetTagsResult> Get()
        {
            var tags = mediator.Request(new TagsQuery());
            var data = new GetTagsResult(tags);
            return new ApiResult<GetTagsResult>(data);
        }

        public ApiResult<PutTagResult> Put(PutTagRequest model)
        {
            var result = new ApiResult<PutTagResult>(false);
            result.AddError(new ErrorDef("This method has not yet been implemented."));
            return result;
        }
    }
}
