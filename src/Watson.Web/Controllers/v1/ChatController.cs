using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watson.Application.Features.Chat.Commands;

namespace Watson.Web.Controllers.v1
{
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ChatController : BaseApiController
    {

        /// <summary>
        ///     Create a new chat session and populate it with the initial bot message.
        /// </summary>
        /// <param name="command">The necessary information to create a chat</param>
        /// <returns code="200">Returns the new unique ID for the created chat session</returns>
        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatSessionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Send a new chat message in an existing session and get a response.
        /// </summary>
        /// <param name="command">The necessary infromation to send a chat message in a session.</param>
        /// <returns code="200">Returns the response from the generative model</returns>
        [HttpPost("message")]
        public async Task<IActionResult> SendMessage(SendChatMessageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        ///     Send a new chat message in an existing session and get a response.
        /// </summary>
        /// <returns code="200">Returns the response from the generative model</returns>
        [HttpPost("richmessage")]
        public async Task<IActionResult> SendAudioAndImageMessage(IFormFile audio, IFormFile image)
        {
            var command = new SendAudioAndImageMessageCommand()
            {
                Audio = audio.OpenReadStream(),
                AudioName = audio.FileName,
                AudioType = audio.ContentType,
                Image = image.OpenReadStream(),
            };

            return Ok(await Mediator.Send(command));
        }
    }
}
