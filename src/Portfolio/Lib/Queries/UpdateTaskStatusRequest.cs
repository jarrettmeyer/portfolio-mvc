using System;

namespace Portfolio.Data.Queries
{
    public class UpdateTaskStatusRequest
    {
        public string Comment { get; set; }
        
        public string IPAddress { get; set; }
        
        public int TaskId { get; set; }
        
        public DateTime Timestamp { get; set; }

        public string ToStatus { get; set; }        
    }
}
