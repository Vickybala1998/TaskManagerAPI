using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Services
{
    public class UserService
    {
        public DbSet<User> _users { get; set; }
    }
}
