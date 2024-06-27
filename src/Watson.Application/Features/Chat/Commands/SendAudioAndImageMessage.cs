using AutoMapper;
using FluentValidation;
using MediatR;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Interfaces.Repositories;
using Watson.Application.Interfaces.Services;
using Watson.Application.Wrappers;

namespace Watson.Application.Features.Chat.Commands
{
    public class SendAudioAndImageMessageCommand : IRequest<Stream>
    {
        public Stream Audio {  get; set; }
        public string AudioName { get; set; }
        public string AudioType { get; set; }
        public Stream Image {  get; set; }
    }

    public class SendAudioAndImageMessageCommandHandler : IRequestHandler<SendAudioAndImageMessageCommand, Stream>
    {
        private readonly IChatSessionRepository _chatSessionsRepository;
        private readonly IMapper _mapper;
        private readonly IAIChatService _aiChatService;
        private readonly IDateTimeService _dateTimeService;

        public SendAudioAndImageMessageCommandHandler(IChatSessionRepository chatSessionRepository, IMapper mapper, IAIChatService aiChatService, IDateTimeService dateTimeService)
        {
            _chatSessionsRepository = chatSessionRepository;
            _mapper = mapper;
            _aiChatService = aiChatService;
            _dateTimeService = dateTimeService;
        }

        public async Task<Stream> Handle(SendAudioAndImageMessageCommand request, CancellationToken cancellationToken)
        {
            // TODO: implement this method, this is pure testing
            var modelResponse = await _aiChatService.InvokeAudioPromptAsync(request.Audio, request.AudioName, request.AudioType, request.Image);
            return modelResponse;
        }
    }

    public class SendAudioAndImageMessageCommandValidator : AbstractValidator<SendAudioAndImageMessageCommand>
    {
        public SendAudioAndImageMessageCommandValidator()
        {
            RuleFor(c => c.Audio)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            //RuleFor(c => c.Image)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .NotNull();
        }
    }
}
