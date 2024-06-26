using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Watson.Application.Interfaces.Repositories;
using Watson.Core.Entities;

namespace Watson.Web.Controllers.v1
{
	[ApiController]
	[Route("[controller]")]
	[ApiVersion("1.0")]
	public class ImageUploadController : ControllerBase
	{
		private readonly INoteImageRepository _noteImageRepository;

		public ImageUploadController(INoteImageRepository noteImageRepository)
		{
			_noteImageRepository = noteImageRepository;
		}

		[HttpPost("{noteId}")]
		[ProducesResponseType(typeof(NoteImage), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(BadRequestResult), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<NoteImage>> UploadImage(string noteId, IFormFile file)
		{
			try
			{
				if (file == null || file.Length == 0)
				{
					return BadRequest("No file uploaded.");
				}

				using (var ms = new MemoryStream())
				{
					await file.CopyToAsync(ms);
					var imageBytes = ms.ToArray();
					var base64String = Convert.ToBase64String(imageBytes);

					// Save the image in NoteImage repository
					var noteImage = new NoteImage
					{
						NoteId = noteId,
						ImageBase64 = base64String
					};

					await _noteImageRepository.AddAsync(noteImage);

					return CreatedAtAction(nameof(UploadImage), new { noteId }, noteImage);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
			}
		}
	}
}
