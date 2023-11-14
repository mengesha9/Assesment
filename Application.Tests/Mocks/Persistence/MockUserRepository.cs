using Moq;
using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using Assesment.Infrastructure.PasswordService;

namespace Assesment.Application.Tests.Mocks;

public class MockUserRepository
{
    public static Mock<IUserRepository> GetMockUserRepository()
    {
        var _passwordHasher = new PasswordHasher();
        var users = new List<User>
        {
            new User
            {
                Name = "User1",
                Email = "User1@gmail.com",
                Password = _passwordHasher.HashPassword("User1password"),
                Id = 1
            },
            new User
            {
                Name = "User2",
                Email = "User2@gmail.com",
                Password = _passwordHasher.HashPassword("User2password"),
                Id = 2
            },
            new User
            {
                Name = "User3",
                Email = "user3@gmail.com",
                Password = _passwordHasher.HashPassword("User3password"),
                Id = 3
            }
        };

        var userRepo = new Mock<IUserRepository>();

        userRepo
            .Setup(repo => repo.GetAsync(It.IsAny<int>()))
            .ReturnsAsync((int id) => users.FirstOrDefault(u => u.Id == id));

        userRepo.Setup(repo => repo.GetAsync()).ReturnsAsync(users);

        userRepo
            .Setup(repo => repo.AddAsync(It.IsAny<User>()))
            .ReturnsAsync(
                (User user) =>
                {
                    user.Id = users.Count + 1;
                    users.Add(user);
                    return user;
                }
            );

        userRepo
            .Setup(repo => repo.UpdateAsync(It.IsAny<User>()))
            .Callback(
                (User user) =>
                {
                    var index = users.FindIndex(u => u.Id == user.Id);
                    if (index >= 0)
                    {
                        users[index] = user;
                    }
                }
            );

        userRepo
            .Setup(repo => repo.DeleteAsync(It.IsAny<User>()))
            .Callback(
                (User user) =>
                {
                    var index = users.FindIndex(u => u.Id == user.Id);
                    if (index >= 0)
                    {
                        users.RemoveAt(index);
                    }
                }
            );

        userRepo
            .Setup(repo => repo.UsernameExists(It.IsAny<string>()))
            .ReturnsAsync((string username) => users.Any(u => u.Name == username));

        userRepo
            .Setup(repo => repo.EmailExists(It.IsAny<string>()))
            .ReturnsAsync((string email) => users.Any(u => u.Email == email));

        
        return userRepo;
    }
}



