using doit.Models;

namespace doit.Services.Abstraction;

public interface IToken
{
    // generate admin token
    string GenerateAdminToken(Admin admin);
    
    bool ValidateToken(string token);
}