﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Watson.Web.Controllers
{
	[Route("api/[controller]")]
	public class BaseApiController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
