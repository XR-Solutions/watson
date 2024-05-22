using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Watson.Web.Endpoints
{
	[ApiController]
	public class PostNoteEndpoint(Mediator mediator) : ControllerBase
	{
		private readonly Mediator mediator = mediator;

		[HttpPost]
		[Route("note")]
		[ProducesResponseType(typeof(Created), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> PostNote()
		{
			var result = mediator.Send();
		}
	}
}
