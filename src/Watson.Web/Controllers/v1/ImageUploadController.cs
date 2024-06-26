using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
		public async Task<ActionResult<NoteImage>> UploadImage(string noteId, [FromBody] NoteImage noteImage)
		{
			try
			{
				if (noteImage == null || string.IsNullOrEmpty(noteImage.ImageBase64))
				{
					return BadRequest("Invalid image data.");
				}

				// Validate the NoteId
				if (noteImage.NoteId != noteId)
				{
					return BadRequest("NoteId mismatch.");
				}

				// Save the image in NoteImage repository
				await _noteImageRepository.AddAsync(noteImage);

				return CreatedAtAction(nameof(UploadImage), new { noteId = noteImage.NoteId }, noteImage);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
			}
		}
	}
}
