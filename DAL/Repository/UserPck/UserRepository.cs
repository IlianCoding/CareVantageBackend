using CVB.BL.Domain.UserPck;
using CVB.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CVB.DAL.Repository.UserPck;

public class UserRepository(KeycloakDbContext context) : IUserRepository
{
    public User GetUserById(Guid id)
    {
        return context.Users
            .Include(p => p.Profile)
            .SingleOrDefault();
    }

    public void AddUser(User user)
    {
        context.Users.Add(user);
    }

    public void UpdateUser(User user)
    {
        context.Users.Update(user);
    }

    public void DeleteUser(User user)
    {
        context.Users.Remove(user);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return context.Users
            .Include(p => p.Profile)
            .ToList();
    }
}