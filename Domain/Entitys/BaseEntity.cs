
using Domain.Interfaces;

namespace Domain.Entitys
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
