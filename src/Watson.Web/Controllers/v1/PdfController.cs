using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Watson.Application.Interfaces.Repositories;
using Watson.Application.Services;
using Watson.Core.Ports;


namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class PdfController(INoteRepository noteRepository, INoteImageRepository noteImageRepository) : BaseApiController
	{
		private readonly INoteRepository noteRepository = noteRepository;
		private readonly INoteImageRepository noteImageRepository = noteImageRepository;

		[HttpGet]
		[Route("sporenmatrix")]
		[ProducesResponseType(typeof(Ok), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetSporenMatrix()
		{
			var notes = await noteRepository.GetAllAsync();
			var images = await noteImageRepository.GetAllAsync();
			var pdf = await PdfService.GenerateSamplePdf(notes, images);
			return File(pdf.ByteArray, pdf.MimeType, pdf.FileName);
		}

		[HttpGet]
		[Route("sporenmatrix/page/{pageNumber}")]
		[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(FileContentResult), StatusCodes.Status404NotFound)]
		public async Task<ActionResult> GetPdfPageAsImage(int pageNumber)
		{
			var notes = await noteRepository.GetAllAsync();
			var images = await noteImageRepository.GetAllAsync();
			var pdf = await PdfService.GenerateSamplePdf(notes, images);

			using (var ms = new MemoryStream(pdf.ByteArray))
			using (var document = PdfiumViewer.PdfDocument.Load(ms))
			{
				if (pageNumber < 1 || pageNumber > document.PageCount)
				{
					var outOfRangePdf = PdfService.GenerateOutOfRangePage();
					using (var outMs = new MemoryStream(outOfRangePdf))
					using (var outDocument = PdfiumViewer.PdfDocument.Load(outMs))
					{
						var page = outDocument.PageSizes[0];
						const int dpi2 = 300;
						int width2 = (int)(page.Width * dpi2 / 72);
						int height2 = (int)(page.Height * dpi2 / 72);

						var image = outDocument.Render(0, width2, height2, dpi2, dpi2, true);
						using (var imgStream = new MemoryStream())
						{
							image.Save(imgStream, ImageFormat.Png);
							return File(imgStream.ToArray(), "image/png");
						}
					}
				}

				var pdfPage = document.PageSizes[pageNumber - 1];
				const int dpi = 300;
				int width = (int)(pdfPage.Width * dpi / 72);
				int height = (int)(pdfPage.Height * dpi / 72);

				var pdfImage = document.Render(pageNumber - 1, width, height, dpi, dpi, true);
				using (var imgStream = new MemoryStream())
				{
					pdfImage.Save(imgStream, ImageFormat.Png);
					return File(imgStream.ToArray(), "image/png");
				}
			}
		}
	}
}
