using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Wrappers;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Application.Features.Notes
{
	public class UpdateNoteCommand : IRequest<Response<bool>>
	{
		public Note Note { get; init; }
	}

	public class UpdateNoteCommandHandler(INoteRepository noteRepository)
		: IRequestHandler<UpdateNoteCommand, Response<bool>>
	{
		private readonly INoteRepository noteRepository = noteRepository;

		public async Task<Response<bool>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
		{
			var note = request.Note;
			await noteRepository.UpdateAsync(note);

			return new Response<bool>(true);
		}
	}
}
