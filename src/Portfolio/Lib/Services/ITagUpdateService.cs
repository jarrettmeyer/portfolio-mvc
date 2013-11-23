using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITagUpdateService
    {
        Tag UpdateCategory(TagInputModel tagInputModel);
    }
}