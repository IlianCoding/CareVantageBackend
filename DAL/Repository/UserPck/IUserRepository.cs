using CVB.BL.Domain.UserPck;

namespace CVB.DAL.Repository.UserPck;

public interface IUserRepository
{
    public User GetUserById(Guid id);
    public void AddUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
    public IEnumerable<User> GetAllUsers();
}