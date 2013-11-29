﻿namespace Portfolio.ViewModels
{
    public class TaskTagInputModel
    {
        public TaskTagInputModel()
        {            
        }

        public TaskTagInputModel(string id, string description)
        {
            Id = id;
            Description = description;
        }

        public string Id { get; set; }
        public string Description { get; set; }
    }
}