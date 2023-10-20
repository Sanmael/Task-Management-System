using Domain.Enums;

namespace Domain.Entitys
{
    public class ProjectTask : BaseEntity
    {
        public long PersonAssigneeId { get; private set; }
        public long PersonCreatedId { get; private set; }
        public string Title { get; private set; } 
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public TaskPriorityType PriorityType { get; private set; }
        public Enums.TaskStatus TaskStatus { get; private set; }
        public long ProjectId { get; private set; }        

        public ProjectTask(long assigneeId, long createdById, string title, string description, DateTime dueDate, DateTime deliveryDate, TaskPriorityType priorityType, Enums.TaskStatus taskStatus, long projectId)
        {
            PersonAssigneeId = assigneeId;
            PersonCreatedId = createdById;
            Title = title;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
            PriorityType = priorityType;
            TaskStatus = taskStatus;
            ProjectId = projectId;
        }
       
        public void UpdateAssignee(Person assignee)
        {
            PersonAssigneeId = assignee.Id;           
            UpdateDate = DateTime.Now;
        }
        public void ChangeDeliveryDateAndDueDate(DateTime deliveryDate, DateTime dueDate)
        {
            DeliveryDate = deliveryDate;
            DueDate = dueDate;
            UpdateDate = DateTime.Now;
        }
        public void UpdateTaskStatus(Enums.TaskStatus taskStatus)
        {
            TaskStatus = taskStatus;
            UpdateDate = DateTime.Now;
        }
        public void UpdateTaskPriorityType(TaskPriorityType taskPriorityType)
        {
            PriorityType = taskPriorityType;
            UpdateDate = DateTime.Now;
        }
    }
}
