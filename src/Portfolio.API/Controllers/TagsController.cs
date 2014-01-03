using System.Web.Http;
using Portfolio.API.Models;
using Portfolio.Lib;
using Portfolio.Lib.Models;
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

        public ApiResult<GetTagResult> Get(int id)
        {
            Tag tag = mediator.Request(new TagByIdQuery(id));
            GetTagResult getTagResult = new GetTagResult(tag);
            return new ApiResult<GetTagResult>(getTagResult);
        }

        public ApiResult<PutTagResult> Put(PutTagRequest model)
        {
            var result = new ApiResult<PutTagResult>(false);
            result.AddError(new ErrorDef("This method has not yet been implemented."));
            return result;
        }
    }
}
