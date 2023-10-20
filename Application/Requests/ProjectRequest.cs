using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class ProjectRequest
    {
        public long CreatedByPersonId { get; private set; }
        public string Name { get; private set; } = string.Empty!;
        public string Description { get; private set; } = string.Empty!;
        public DateTime DueDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }

        public ProjectRequest(long createdByPersonId, string name, string description, DateTime dueDate, DateTime deliveryDate)
        {
            CreatedByPersonId = createdByPersonId;
            Name = name;
            Description = description;
            DueDate = dueDate;
            DeliveryDate = deliveryDate;
        }
    }
}
