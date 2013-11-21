﻿using System;
using System.Collections.Generic;
using Portfolio.Web.Models;

namespace Portfolio.Models
{
    public class Task : IVersionedEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? DueOn { get; set; }
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime? CompletedAt { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
        public virtual byte[] Version { get; set; }
    }
}
