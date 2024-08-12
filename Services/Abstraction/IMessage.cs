using doit.Models;
using doit.Models.DTOs;

namespace doit.Services.Abstraction;

public interface IMessage
{
    // Craete a new message
    Task<Message> CreateMessageAsync(MessageDTO messageDTO);
    
    // Get all messages
    Task<PaginatedList<Message>> GetMessagesAsync(int pageNumber, int pageSize);
    
    // add subject to message
    Task<Message> AddSubjectAsync(int messageId, string subject);

}