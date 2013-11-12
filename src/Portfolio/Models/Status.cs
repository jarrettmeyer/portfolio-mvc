using System.Collections.Generic;
using Portfolio.Web.Models;

namespace Portfolio.Models
{
    public class Status
    {
        public virtual string Id { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual bool IsDefaultStatus { get; set; }

        public virtual IList<StatusWorkflow> Workflows { get; set; }
    }
}
