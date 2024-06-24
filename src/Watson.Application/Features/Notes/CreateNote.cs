using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Wrappers;
using Watson.Core.Entities;
using Watson.Core.Ports;

namespace Watson.Application.Features.Notes
{
	public class CreateNoteCommand : IRequest<Response<Note>>
	{
		public Note Note { get; init; }
	}

	public class CreateNoteCommandHandler(INoteRepository noteRepository)
		: IRequestHandler<CreateNoteCommand, Response<Note>>
	{
		private readonly INoteRepository noteRepository = noteRepository;

		public async Task<Response<Note>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
		{
			var note = request.Note;

			var result = await noteRepository.AddAsync(note);

			return new Response<Note>(result);
		}
	}

	public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
	{
		public CreateNoteCommandValidator()
		{
			RuleFor(t => t.Note)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull();
		}
	}

}
