using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watson.Application.Features.Notes;
using Watson.Core.Entities;

namespace Watson.Web.Controllers.v1
{
	[Route("[controller]")]
	[ApiVersion("1.0")]
    [ApiController]
    public class NoteController : BaseApiController
	{
		/// <summary>
		///		Add a new note to a Crime Scene
		/// </summary>
		/// <param name="note">A note object containing all information to a note</param>
		/// <returns>The GUID of the newly created Note</returns>
		[HttpPost]
		public async Task<ActionResult> CreateNote(
			[FromBody] Note note
		)
		{
			var command = new CreateNoteCommand { Note = note };
			var result = await Mediator.Send(command);

			return Created("note", result);
		}

		/// <summary>
		///		Update an existing Note within a Crime Scene
		/// </summary>
		/// <param name="note"></param>
		/// <returns>A boolean indicator whether the Note has been successfully updated</returns>
		[HttpPut]
		public async Task<ActionResult> UpdateNote(
			[FromBody] Note note
		)
		{
			var command = new UpdateNoteCommand { Note = note };
			var result = await Mediator.Send(command);

			return Ok(result);
		}

		/// <summary>
		///		Gets all notes belonging within a Crime Scene
		/// </summary>
		/// <returns>A paginated list with all Notes</returns>
		[HttpGet]
		[Route("all")]
		public async Task<ActionResult> GetAllNotes(
		)
		{
			var command = new GetAllNotesQuery { };
			var result = await Mediator.Send(command);

			return Ok(result);
		}
	}
}
