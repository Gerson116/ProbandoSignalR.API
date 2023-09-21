using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProbandoSignalR.API.Hubs;
using ProbandoSignalR.API.Models;

namespace ProbandoSignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<MessageHub> _hubContext;

        public ChatController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage([FromBody] ChatElement chat)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage", chat);
            return Ok(chat);
        }
    }
}
