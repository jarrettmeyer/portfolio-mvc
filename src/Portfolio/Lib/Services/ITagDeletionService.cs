using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ITagDeletionService
    {
        Tag DeleteCategory(string id);
    }
}