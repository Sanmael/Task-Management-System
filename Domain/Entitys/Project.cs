
namespace Domain.Entitys
{
    public class Project : BaseEntity
    {
        public Person CreatedBy { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; } 
        public List<ProjectTask> Tasks { get; private set; } = new List<ProjectTask>();

        public Project(Person createdBy, string name, string description, List<ProjectTask> tasks)
        {
            CreatedBy = createdBy;
            Name = name;
            Description = description;
            Tasks = tasks;
        }
    }
}
