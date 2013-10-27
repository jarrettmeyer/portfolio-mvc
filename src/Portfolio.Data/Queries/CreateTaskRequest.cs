using System;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class CreateTaskRequest
    {
        private readonly string ipAddress;
        private readonly Task task;
        private readonly DateTime timestamp;

        public CreateTaskRequest(Task task, string ipAddress, DateTime timestamp)
        {
            this.task = task;
            this.ipAddress = ipAddress;
            this.timestamp = timestamp;
        }

        public string IPAddress
        {
            get { return ipAddress; }
        }

        public Task Task
        {
            get { return task; }
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
        }
    }
}