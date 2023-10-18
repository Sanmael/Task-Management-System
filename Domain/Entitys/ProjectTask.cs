using Domain.Enums;

namespace Domain.Entitys
{
    public class ProjectTask : BaseEntity
    {
        public Person Assignee { get; private set; }
        public Person CreatedBy { get; private set; }
        public string Title { get; private set; } 
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public TaskPriorityType PriorityType { get; private set; }
        public Enums.TaskStatus TaskStatus { get; private set; }
        public Project Project { get; private set; }
        public ProjectTask(Person assignee, Person createdBy, string title, string description, DateTime dueDate, DateTime deliveryDate, TaskPriorityType priorityType, Enums.TaskStatus taskStatus, Project project)
        {
            Assignee = assignee;
            CreatedBy = createdBy;
            Title = title;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
            PriorityType = priorityType;
            TaskStatus = taskStatus;
            Project = project;
        }
        public void UpdateAssignee(Person assignee)
        {
            Assignee = assignee;           
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
