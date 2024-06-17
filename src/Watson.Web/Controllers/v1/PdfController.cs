using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Watson.Application.Services;

namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class PdfController : BaseApiController
	{
		[HttpGet]
		[Route("sporenmatrix")]
		[ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetAllNotes(
)
		{
			var pdf = await PdfService.GenerateSamplePdf();
			return File(pdf.ByteArray, pdf.MimeType, pdf.FileName);
		}
	}
}
