using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public PersonDTO CreatedBy { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public DateTime? DeletionDate { get; private set; }
        public List<ProjectTaskDTO> Tasks { get; private set; }

        public void AddTasks(List<ProjectTaskDTO> tasks)
        {
            Tasks = new List<ProjectTaskDTO>();

            Tasks.AddRange(tasks);
        }
              
        public ProjectDTO(long id, PersonDTO createdBy, string name, string description, DateTime dueDate, DateTime deliveryDate, DateTime? deletionDate)
        {
            Id = id;
            CreatedBy = createdBy;
            Name = name;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
            DeletionDate = deletionDate;            
        }
    }
}
