using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ProjectTaskDTO
    {
        public long Id { get; set; }
        public PersonDTO Assignee { get; private set; }
        public PersonDTO CreatedBy { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int PriorityType { get; private set; }
        public int TaskStatus { get; private set; }
        public long ProjectId { get; private set; }        
        public ProjectTaskDTO(long id, PersonDTO assignee, PersonDTO createdBy, string title, string description, DateTime dueDate, DateTime deliveryDate, int priorityType, int taskStatus, long projectId)
        {
            Id = id;
            Assignee = assignee;
            CreatedBy = createdBy;
            Title = title;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
            PriorityType = priorityType;
            TaskStatus = taskStatus;
            ProjectId = projectId;
        }      
    }
}
