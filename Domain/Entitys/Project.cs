
namespace Domain.Entitys
{
    public class Project : BaseEntity
    {
        public long PersonCreatedBy { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public DateTime? DeletionDate { get; private set; }

        public Project(long personCreatedBy, string name, string description, DateTime dueDate, DateTime deliveryDate)
        {
            PersonCreatedBy = personCreatedBy;
            Name = name;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
            DeletionDate = null;
        }
    }
}
