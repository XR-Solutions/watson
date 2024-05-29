﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watson.Application.Features.Notes;
using Watson.Core.Entities;

namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("api/v1/[controller]")]
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
			var result = Mediator.Send(command);

			return Created("note", result);
		}
	}
}
