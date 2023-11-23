using TaskManagerAPI.Model;

namespace TaskManagerAPI.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task <User?> GetUserById(string Email);

        Task AddUser(UserModel user);

        Task RemoveUser(int id);

        Task UpdateUser(UserModel user);

        Task<User> loginUser(UserModel user);    
    }
}
