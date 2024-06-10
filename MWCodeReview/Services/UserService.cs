using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MWCodeReview.Interfaces;
using MWCodeReview.Models;

namespace MWCodeReview.Services
{
    public class UserService : IUser
    {

        private readonly MW_DB_TESTContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(MW_DB_TESTContext context,ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> DeleteUser(uint id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);

                if (user == null) return false;
                
                _context.Users.Remove(user);


                if (await _context.SaveChangesAsync() > 0)
                {
                    _logger.LogInformation($"The user with Login = {user.Login} has been deleted.");
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                _logger.LogError($"During delete appear unexpected error - {ex}");
                return false;
            }
           
        }
    }
}
