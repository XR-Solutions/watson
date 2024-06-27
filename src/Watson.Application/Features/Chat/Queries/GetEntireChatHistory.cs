using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watson.Application.Interfaces.Services;
using Watson.Application.Wrappers;

namespace Watson.Application.Features.Chat.Queries
{
    // This is ugle and should be removed, this should be paginated
    public class GetEntireChatHistoryQuery : IRequest<Response<object>>
    {
    }

    public class GetEntireChatHistoryQueryHandler : IRequestHandler<GetEntireChatHistoryQuery, Response<object>>
    {
        private readonly IAIChatService _aiChatService;

        public GetEntireChatHistoryQueryHandler(IAIChatService aIChatService)
        {
            _aiChatService = aIChatService;
        }

        public async Task<Response<object>> Handle(GetEntireChatHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = _aiChatService.GetEntireChatHistory();
            return new Response<object>(history);
        }
    }

}
