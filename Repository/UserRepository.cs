using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using TaskManagerAPI.Data;
using TaskManagerAPI.Model;

namespace TaskManagerAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) {

            _dataContext = dataContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dataContext._users.ToListAsync();
        }

        public async Task<User?> GetUserById(string Email)
        {
            return await _dataContext._users.FirstOrDefaultAsync(user=>user.Email==Email);
        }

        public async Task AddUser(UserModel user)
        {
            User _user= processImage(user);
            await _dataContext._users.AddAsync(_user);  
            _dataContext.SaveChanges();
        }

        public User processImage(UserModel _user)
        {
            User user = new User();
            if (_user != null)
            {
                user.Email = _user.Email;
                user.EmployeeName = _user.EmployeeName;
                user.Password=_user.Password;
                user.Role=_user.Role;
                user.Department = _user.Department;
                if (_user.ImageFile != null)
                {
                    using (var memorystream = new MemoryStream())
                    {
                        _user.ImageFile.CopyToAsync(memorystream);
                        user.Image=memorystream.ToArray();  
                    }

                }
            }
            return user;
        }

        public async Task RemoveUser(int id)
        {
            User? user=await _dataContext._users.FirstOrDefaultAsync(_user=>_user.Id==id);
            if (user!=null)
            {
                _dataContext._users.Remove(user);
            }
        }

        public async Task UpdateUser(UserModel user)
        {
            var exisitingUser= _dataContext._users.FirstOrDefault(u=>u.Id==user.Id);

            if (exisitingUser!=null)
            {
                if(user.EmployeeName!=null && user.EmployeeName!=exisitingUser.EmployeeName) {
                    exisitingUser.EmployeeName = user.EmployeeName;
                }

                if (user.Email != null && user.Email != exisitingUser.Email)
                {
                    exisitingUser.Email = user.Email;
                }
                if (user.Password != null && user.Password != exisitingUser.Password)
                {
                    exisitingUser.Password = user.Password;
                }
                if (user.Department != null && user.Department != exisitingUser.Department)
                {
                    exisitingUser.Department = user.Department;
                }
                if (user.Role != null && user.Role != exisitingUser.Role)
                {
                    exisitingUser.Role = user.Role;
                }

                //_dataContext._users.Update(exisitingUser);
            }
            
            await _dataContext.SaveChangesAsync(true);
        }

        public Task<User> loginUser(UserModel _user)
        {
            User? userdetails = new User();
            if (_dataContext!=null && _dataContext._users!=null)
            {
                userdetails = _dataContext._users.FirstOrDefault(user => user.Email == _user.Email);
                if (userdetails != null && userdetails.Password==_user.Password)
                {
                    return Task.FromResult(userdetails);
                }

                else
                {
                    return Task.FromResult(userdetails);
                }
            }
            else
            {
                return Task.FromResult(userdetails);
            }
        }
            

    }
}
