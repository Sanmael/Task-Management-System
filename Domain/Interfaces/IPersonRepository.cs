using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPersonRepository
    {
        public Task InsertPerson(Person person);
        public Task<Person?> GetPersonById(long id);
    }
}
