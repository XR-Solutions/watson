using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Application.Interfaces.Repositories;
using Watson.Application.Interfaces.Services;
using Watson.Application.Wrappers;
using Watson.Core.Entities;

namespace Watson.Application.Features.Chat.Commands
{
    public class SendChatMessageCommand : IRequest<Response<SendChatMessageResponse>>
    {
        public Guid SessionId { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class SendChatMessageCommandHandler : IRequestHandler<SendChatMessageCommand, Response<SendChatMessageResponse>>
    {
        private readonly IChatSessionRepository _chatSessionsRepository;
        private readonly IMapper _mapper;
        private readonly IAIChatService _aiChatService;
        private readonly IDateTimeService _dateTimeService;

        public SendChatMessageCommandHandler(IChatSessionRepository chatSessionRepository, IMapper mapper, IAIChatService aiChatService, IDateTimeService dateTimeService)
        {
            _chatSessionsRepository = chatSessionRepository;
            _mapper = mapper;
            _aiChatService = aiChatService;
            _dateTimeService = dateTimeService;
        }

        public async Task<Response<SendChatMessageResponse>> Handle(SendChatMessageCommand request, CancellationToken cancellationToken)
        {
            // TODO: implement this method, this is pure testing
            var modelResponse = await _aiChatService.InvokePromptAsync(request.Message);
            var response = new SendChatMessageResponse() { Message = modelResponse };
            return new Response<SendChatMessageResponse>(response);
        }
    }

    public class SendChatMessageCommandValidator : AbstractValidator<SendChatMessageCommand>
    {
        public SendChatMessageCommandValidator()
        {
            RuleFor(c => c.Message)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            // TODO: check if the chat session exists
        }
    }

    public class SendChatMessageResponse
    {
        public string Message {  get; set; } = string.Empty;
    }
}
