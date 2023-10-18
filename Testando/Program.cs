using DataAccess.Tests.BaseRepository;
using DataAccess.Tests.Repositories;
using Domain.Entitys;
using Domain.Interfaces;

MockEntityRepository mockEntityRepository = new MockEntityRepository();
IBaseRepository baseRepository = new BaseMockRepository(mockEntityRepository);
IUserRepository userRepository = new MockUserRepository(baseRepository, mockEntityRepository);


var user = new User("password123", "user@example.com", "123-456-7890", "john_doe");
var user2 = new User("password123", "user1@example.com", "123-456-7890", "john_doe");

await userRepository.InsertUser(user);
await userRepository.InsertUser(user2);

User userEmail = await userRepository.GetUserByEmail(user2.Email);

Console.WriteLine($"Email é {userEmail.Email}");