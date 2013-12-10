using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITagUpdateService
    {
        Tag UpdateCategory(TagInputModel tagInputModel);
    }
}