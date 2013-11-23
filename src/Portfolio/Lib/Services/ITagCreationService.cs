using Portfolio.Models;
using Portfolio.ViewModels;

namespace Portfolio.Lib.Services
{
    public interface ITagCreationService
    {
        Tag CreateCategory(TagInputModel tagInputModel);
    }
}