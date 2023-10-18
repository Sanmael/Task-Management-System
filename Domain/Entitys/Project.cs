﻿
namespace Domain.Entitys
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; } 
        public List<ProjectTask> Tasks { get; private set; } = new List<ProjectTask>();
        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }        
    }
}
