using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Watson.Application.Features.Notes;
using Watson.Core.Entities;
using Watson.Web.Hubs;

namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class NoteController(IHubContext<NotesHub> hubContext) : BaseApiController
	{
		private readonly IHubContext<NotesHub> hubContext = hubContext;

		[HttpPost]
		[ProducesResponseType(typeof(Created), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> CreateNote(
			[FromBody] Note note
		)
		{
			var command = new CreateNoteCommand { Note = note };
			var result = await Mediator.Send(command);

			return Created("note", result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> UpdateNote(
			[FromBody] Note note
		)
		{
			var command = new UpdateNoteCommand { Note = note };
			var result = await Mediator.Send(command);

			await hubContext.Clients.All.SendAsync("ReceiveNoteUpdate", note.Guid);

			return Ok(result);
		}

		[HttpGet]
		[Route("all")]
		[ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetAllNotes(
		)
		{
			var command = new GetAllNotesQuery { };
			var result = await Mediator.Send(command);

			return Ok(result);
		}

		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(typeof(OkObjectResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetNoteById(string id)
		{
			var command = new GetNoteByIdQuery { NoteId = id };
			var result = await Mediator.Send(command);

			if (result == null)
			{
				return NotFound();
			}

			return Ok(result);
		}

	}
}
