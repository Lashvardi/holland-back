using System.Threading.Tasks;
using doit.Data;
using doit.Models;
using doit.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using doit.Exceptions;
using doit.Models.DTOs;

namespace doit.Services.Implementation
{
    public class AdminAuth : IAdminAuth
    {


        private readonly DataContext _context;
        private readonly IAdminHelperMethods _adminHelperMethods;
        private readonly IToken _token;

        public AdminAuth(DataContext context, IAdminHelperMethods adminHelperMethods, IToken token)
        {
            _context = context;
            _adminHelperMethods = adminHelperMethods;
            _token = token;
        }

        public async Task<string> AuthenticateAdmin(AdminDto adminDto)
        {
            if (!await _adminHelperMethods.AdminExists(adminDto.Email))
            {
                throw new AlreadyExistException("Admin does not exist");
            }

            var admin = await _context.Admins.SingleOrDefaultAsync(a => a.Email == adminDto.Email);

            if (admin != null && BCrypt.Net.BCrypt.Verify(adminDto.Password, admin.Password))
            {
                var token = _token.GenerateAdminToken(admin);
                return token;
            }

            throw new InvalidCredentialsException("Invalid credentials");


        }

        public async Task<bool> RegisterAdmin(AdminDto adminDto)
        {
            // Check if admin already exists
            if (await _adminHelperMethods.AdminExists(adminDto.Email))
            {
                return false;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(adminDto.Password);

            var admin = new Admin
            {
                Email = adminDto.Email,
                Password = hashedPassword
            };

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}