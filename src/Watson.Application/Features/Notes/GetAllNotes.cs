using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Wrappers;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Application.Features.Notes
{
	public class GetAllNotesCommand : IRequest<Response<IReadOnlyList<Note>>>
	{

	}

	public class GetAllNotesCommandHandler(INoteRepository noteRepository)
		: IRequestHandler<GetAllNotesCommand, Response<IReadOnlyList<Note>>>
	{
		public async Task<Response<IReadOnlyList<Note>>> Handle(GetAllNotesCommand request, CancellationToken cancellationToken)
		{
			var notes = await noteRepository.GetAllAsync();

			return new Response<IReadOnlyList<Note>>(notes);
		}
	}
}
