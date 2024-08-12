using doit.Data;
using doit.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace doit.Services.Implementation;

public class AdminHelperMethods : IAdminHelperMethods
{
    private readonly DataContext _context;
    
    public AdminHelperMethods(DataContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> AdminExists(string email)
    {
        return await _context.Admins.AnyAsync(a => a.Email == email);
    }
}