using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Tasky.Shared;

namespace Tasky.Server.Data.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if(await UserExists(user.Email))
            {
                return new ServiceResponse<int> { 
                    Success = false,
                    Message = "User already exists."
                };
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = user.UserId,
                Success = true,
                Message = "Successful Registration!"
            };
        }


        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if(user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
            }
            else
            {
                response.Data = "token";
            }

            return response;
            
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
