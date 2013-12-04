using Portfolio.Models;

namespace Portfolio.Lib.Services
{
    public interface ITagDeletionService
    {
        Tag DeleteTag(int id);
    }
}