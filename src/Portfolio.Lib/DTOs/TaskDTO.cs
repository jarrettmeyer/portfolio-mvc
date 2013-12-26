using System;

namespace Portfolio.Lib.DTOs
{
    public class TaskDTO
    {
        public string Description { get; set; }

        public DateTime? DueOn { get; set; }

        public int Id { get; set; }

        public TagDTO[] Tags { get; set; }

        public string Title { get; set; }
    }
}
