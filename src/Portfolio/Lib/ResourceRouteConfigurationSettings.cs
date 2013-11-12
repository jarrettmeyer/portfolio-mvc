namespace Portfolio.Lib
{
    public class ResourceRouteConfigurationSettings
    {
        private bool includeShowAction = true;
        private string indexActionName = "Index";
        private string showActionName = "Show";
        private string showActionParameter = "id";
        private bool useDeleteHttpMethod = true;

        public virtual bool IncludeShowAction
        {
            get { return includeShowAction; }
            set { includeShowAction = value; }
        }

        public virtual string IndexActionName
        {
            get { return indexActionName; }
            set { indexActionName = value; }
        }

        public virtual string ShowActionName
        {
            get { return showActionName; }
            set { showActionName = value; }
        }

        public virtual string ShowActionParameter
        {
            get { return showActionParameter; }
            set { showActionParameter = value; }
        }

        public virtual bool UseDeleteHttpMethod
        {
            get { return useDeleteHttpMethod; }
            set { useDeleteHttpMethod = value; }
        }
    }
}