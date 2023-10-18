using Domain.Enums;

namespace Domain.Entitys
{
    public class Person : BaseEntity
    {
       
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthday { get; private set; }
        public decimal Salary { get; private set; }
        public JobPosition JobPosition { get; private set; }

        public Person(string firstName, string lastName, int age, DateTime birthday, decimal salary, JobPosition jobPosition)
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Birthday = birthday;
            Salary = salary;
            JobPosition = jobPosition;
        }
        public void UpdateJobPosition(JobPosition jobPosition, decimal newSalary)
        {
            JobPosition = jobPosition;
            UpdateDate = DateTime.Now;
            Salary = newSalary;
        }        
    }
}
