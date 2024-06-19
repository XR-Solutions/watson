using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Wrappers;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Application.Features.Notes
{
	public class GetNoteByIdQuery : IRequest<Response<Note>>
	{
		public string NoteId { get; set; }
	}

	public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, Response<Note>>
	{
		private readonly INoteRepository _noteRepository;

		public GetNoteByIdQueryHandler(INoteRepository noteRepository)
		{
			_noteRepository = noteRepository;
		}

		public async Task<Response<Note>> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
		{
			var id = Guid.Parse(request.NoteId);
			var note = await _noteRepository.GetByIdAsync(id);

			return new Response<Note>(note);
		}
	}
}
