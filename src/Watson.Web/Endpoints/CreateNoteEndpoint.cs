using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Watson.Application.Features.Notes;
using Watson.Core.Entities;

namespace Watson.Web.Endpoints
{
	[ApiController]
	public class CreateNoteEndpoint() : ControllerBase
	{
		private IMediator mediator;
		protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();

		[HttpPost]
		[Route("note")]
		[ProducesResponseType(typeof(Created), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> CreateNote(
			[FromBody] Note note
		)
		{
			var command = new CreateNoteCommand { Note = note };
			var result = mediator.Send(command);

			return Created("note", result);
		}
	}
}
