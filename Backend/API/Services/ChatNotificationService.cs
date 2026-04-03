using API.Hubs;
using Application.DTO.Messages;
using Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace API.Services
{
    public class ChatNotificationService : IChatNotificationService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatNotificationService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(Guid conversationId, MessageDto message)
        {
            await _hubContext.Clients
                .Group(conversationId.ToString())
                .SendAsync("ReceiveMessage", message);
            Console.WriteLine($"Korisnik je usao u grupu: {conversationId}");

        }
    }
}
