using Blazor_Test.Data;
using Blazor_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Test.Services
{
    public class UserServices
{
    private readonly MyDbContext _context;

    public UserServices(MyDbContext context)
    {
        _context = context;
    }

        public User[] GetAllUsers()
        {
            return _context.Users
                .ToArray();
        }

        public async Task SaveUsersAsync(List<User> users)
        {
            _context.Users.AddRange(users);
            await _context.SaveChangesAsync();
        }
}
}
