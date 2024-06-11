using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watson.Application.Features.Notes;
using Watson.Core.Entities;

namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class NoteController : BaseApiController
	{
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
	}
}
