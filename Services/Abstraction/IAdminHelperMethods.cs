    using doit.Models;

    namespace doit.Services.Abstraction;

    public interface IAdminHelperMethods
    {
        // Admin Exists
        Task<bool> AdminExists(string email);
        
    }