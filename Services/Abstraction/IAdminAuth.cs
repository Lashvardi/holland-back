using doit.Models.DTOs;

namespace doit.Services.Abstraction;

public interface IAdminAuth
{
    Task<string> AuthenticateAdmin(AdminDto adminDto);
    
    Task<bool> RegisterAdmin(AdminDto adminDto);
}