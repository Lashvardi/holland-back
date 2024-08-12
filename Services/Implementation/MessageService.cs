using System.Linq;
using System.Threading.Tasks;
using doit.Data;
using doit.Models;
using doit.Models.DTOs;
using doit.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace doit.Services.Implementation
{
    public class MessageService : IMessage
    {
        private readonly DataContext _context;

        public MessageService(DataContext context)
        {
            _context = context;
        }

        public async Task<Message> CreateMessageAsync(MessageDTO messageDTO)
        {
            var lastOrderNumber = await _context.Messages.OrderByDescending(m => m.orderNumber).Select(m => m.orderNumber).FirstOrDefaultAsync();

            var newMessage = new Message
            {
                FullName = messageDTO.FullName,
                Email = messageDTO.Email,
                PhoneNumber = messageDTO.PhoneNumber,
                orderNumber = lastOrderNumber + 1
            };

            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();

            return newMessage;
        }
        

        public async Task<PaginatedList<Message>> GetMessagesAsync(int pageNumber, int pageSize)
        {
            var messagesQuery = _context.Messages.AsQueryable();

            var count = await messagesQuery.CountAsync();
            var items = await messagesQuery
                .OrderByDescending(m => m.orderNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<Message>(items, count, pageNumber, pageSize);
        }
        
        public async Task<Message> AddSubjectAsync(int messageId, string subject)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
            message.Subjects = subject;
            await _context.SaveChangesAsync();
            return message;
        }
    }
}