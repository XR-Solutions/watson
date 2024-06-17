using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Watson.Application.Services
{
	public static class PdfService
	{
		public static async Task<PdfFileInfo> GenerateSamplePdf()
		{
			try
			{
				Document document = Document.Create(container =>
				{
					container.Page(page =>
					{
						page.Size(PageSizes.A4);
						page.Margin(2, Unit.Centimetre);
						page.PageColor(Colors.White);
						page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial", "Calibri", "Tahoma"));

						page.Content().Column(x =>
						{

						});



						page.Footer()
							.AlignCenter()
							.Text(x =>
							{
								x.Span("THIS IS A SYSTEM GENERATED MAIL, PLEASE DO NOT REPLY TO THIS EMAIL.").FontSize(9);
							});
					});
				});

				byte[] pdfBytes = document.GeneratePdf();

				return new PdfFileInfo()
				{
					ByteArray = pdfBytes,
					FileName = "sporenmatrix.pdf",
					MimeType = "application/pdf"
				};
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
