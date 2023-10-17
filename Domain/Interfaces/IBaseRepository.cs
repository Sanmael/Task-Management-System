using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository
    {
        public Task InsertAsync(BaseEntity entity);
        public Task UpdateAsync(BaseEntity entity);
        public Task DeleteAsync(BaseEntity entity);
    }
}
