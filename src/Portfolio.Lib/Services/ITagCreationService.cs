using Portfolio.Lib.Models;
using Portfolio.Lib.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITagCreationService
    {
        Tag CreateCategory(TagInputModel tagInputModel);
    }
}