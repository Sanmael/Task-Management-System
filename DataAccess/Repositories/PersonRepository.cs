using Dapper;
using Domain.Entitys;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISession _session;

        public PersonRepository(IBaseRepository baseRepository, ISession session)
        {
            _baseRepository = baseRepository;
            _session = session;
        }

        public async Task<Person?> GetPersonById(long id)
        {
            string query = "SELECT * FROM PERSON WHERE PERSONID = @id";
            return await _session.Connection.ExecuteScalarAsync<Person>(sql: query, id);
        }

        public async Task InsertPerson(Person person)
        {
            await _baseRepository.InsertAsync(person);
        }
    }
}
