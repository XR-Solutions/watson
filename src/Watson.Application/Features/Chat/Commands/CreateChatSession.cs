using AutoMapper;
using FluentValidation;
using MediatR;
using Watson.Application.Interfaces.Repositories;
using Watson.Application.Interfaces.Services;
using Watson.Application.Wrappers;
using Watson.Core.Entities;

namespace Watson.Application.Features.Chat.Commands
{
    public class CreateChatSessionCommand : IRequest<Response<Guid>>
    {
        public string Title { get; set; } = "";
    }

    public class CreateChatSessionCommandHandler : IRequestHandler<CreateChatSessionCommand, Response<Guid>>
    {
        private readonly IChatSessionRepository _chatSessionRepository;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public CreateChatSessionCommandHandler(IChatSessionRepository chatSessionRepository, IMapper mapper, IDateTimeService dateTimeService)
        {
            _chatSessionRepository = chatSessionRepository;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }

        public async Task<Response<Guid>> Handle(CreateChatSessionCommand request, CancellationToken cancellationToken)
        {
            var chatSession = _mapper.Map<ChatSession>(request);
            chatSession.CreatedOn = _dateTimeService.NowUtc();
            await _chatSessionRepository.AddAsync(chatSession);

            return new Response<Guid>(chatSession.Id);
        }
    }

    public class CreateChatSessionCommandValidator : AbstractValidator<CreateChatSessionCommand>
    {
        public CreateChatSessionCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(75).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }

    public class CreateChatSessionProfile : Profile
    {
        public CreateChatSessionProfile()
        {
            CreateMap<CreateChatSessionCommand, ChatSession>();
        }
    }
}
