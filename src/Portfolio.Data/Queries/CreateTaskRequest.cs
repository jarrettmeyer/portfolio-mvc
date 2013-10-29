using System;
using Portfolio.Data.Models;

namespace Portfolio.Data.Queries
{
    public class CreateTaskRequest
    {
        private readonly string ipAddress;
        private readonly int? selectedCategory;
        private readonly Task task;
        private readonly DateTime timestamp;

        public CreateTaskRequest(Task task, int? selectedCategory, string ipAddress, DateTime timestamp)
        {
            this.task = task;
            this.selectedCategory = selectedCategory;
            this.ipAddress = ipAddress;
            this.timestamp = timestamp;
        }

        public string IPAddress
        {
            get { return ipAddress; }
        }

        public int? SelectedCategory
        {
            get { return selectedCategory; }
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