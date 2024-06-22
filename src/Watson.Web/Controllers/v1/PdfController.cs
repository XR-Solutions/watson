using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Watson.Application.Services;
using Watson.Core.Ports;


namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class PdfController(INoteRepository noteRepository) : BaseApiController
	{
		private readonly INoteRepository noteRepository = noteRepository;

		[HttpGet]
		[Route("sporenmatrix")]
		[ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetSporenMatrix()
		{
			var notes = await noteRepository.GetAllAsync();
			var pdf = await PdfService.GenerateSamplePdf(notes);
			return File(pdf.ByteArray, pdf.MimeType, pdf.FileName);
		}

		[HttpGet]
		[Route("sporenmatrix/page/{pageNumber}")]
		[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetPdfPageAsImage(int pageNumber)
		{
			var notes = await noteRepository.GetAllAsync();
			var pdf = await PdfService.GenerateSamplePdf(notes);

			using (var ms = new MemoryStream(pdf.ByteArray))
			using (var document = PdfiumViewer.PdfDocument.Load(ms))
			{
				if (pageNumber < 1 || pageNumber > document.PageCount)
				{
					return NotFound("Page number out of range.");
				}

				var page = document.PageSizes[pageNumber - 1];
				const int dpi = 300;
				int width = (int)(page.Width * dpi / 72);
				int height = (int)(page.Height * dpi / 72);

				var image = document.Render(pageNumber - 1, width, height, dpi, dpi, true);
				using (var imgStream = new MemoryStream())
				{
					image.Save(imgStream, ImageFormat.Png);
					return File(imgStream.ToArray(), "image/png");
				}
			}
		}
	}
}
