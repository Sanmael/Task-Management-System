using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }
        public int JobPosition { get; set; }
        public PersonDTO()
        {
            
        }
        public PersonDTO(long userId, string firstName, string lastName, int age, DateTime birthday, decimal salary, int jobPosition)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Birthday = birthday;
            Salary = salary;
            JobPosition = jobPosition;
            UserId = userId;
        }
        public PersonDTO(long id, long userId, string firstName, string lastName, int age, DateTime birthday, decimal salary, int jobPosition)
        {
            Id = id;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Birthday = birthday;
            Salary = salary;
            JobPosition = jobPosition;
        }
    }
}
