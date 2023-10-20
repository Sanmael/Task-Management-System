using Domain.Entitys;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class ProjectTaskRequest
    {
        public long PersonAssigneeId { get; private set; } 
        public long PersonCreatedId { get; private set; }
        public string Title { get; private set; } = string.Empty!;
        public string Description { get; private set; } = string.Empty!;
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int PriorityType { get; private set; }
        public int TaskStatus { get; private set; }
        public long ProjectId { get; private set; }

        public ProjectTaskRequest(long personAssigneeId, long personCreatedId, string title, string description, DateTime dueDate, DateTime deliveryDate, int priorityType, int taskStatus, long projectId)
        {
            PersonAssigneeId = personAssigneeId;
            PersonCreatedId = personCreatedId;
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
