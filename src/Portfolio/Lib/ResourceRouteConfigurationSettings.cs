namespace Portfolio.Lib
{
    public class ResourceRouteConfigurationSettings
    {
        private string deleteHttpMethod = "DELETE";
        private string idConstraint = @"\d+";
        private bool includeDeleteAction = true;
        private bool includeShowAction = true;
        private string indexActionName = "Index";
        private string showActionName = "Show";
        private bool useDistinctDeleteUrl = true;

        public virtual string DeleteHttpMethod
        {
            get { return deleteHttpMethod; }
            set { deleteHttpMethod = value; }
        }

        public virtual string IdConstraint
        {
            get { return idConstraint; }
            set { idConstraint = value; }
        }

        public virtual bool IncludeDeleteAction
        {
            get { return includeDeleteAction; }
            set { includeDeleteAction = value; }
        }

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

        public virtual bool UseDistinctDeleteUrl
        {
            get { return useDistinctDeleteUrl; }
            set { useDistinctDeleteUrl = value; }
        }
    }
}