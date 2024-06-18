using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Wrappers;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Application.Features.Notes
{
	public class GetAllNotesQuery : IRequest<Response<IReadOnlyList<Note>>>
	{

	}

	public class GetAllNotesQueryHandler(INoteRepository noteRepository)
		: IRequestHandler<GetAllNotesQuery, Response<IReadOnlyList<Note>>>
	{
		public async Task<Response<IReadOnlyList<Note>>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
		{
			var notes = await noteRepository.GetAllAsync();

			return new Response<IReadOnlyList<Note>>(notes);
		}
	}
}
