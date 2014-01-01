using Portfolio.Lib.Models;

namespace Portfolio.Lib.Queries
{
    public class ActiveTagsQuery : IQuery<TagCollection>
    {
        private bool isActive = true;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
