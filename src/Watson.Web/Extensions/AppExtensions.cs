﻿using Microsoft.AspNetCore.Builder;
using Watson.Web.Middlewares;

namespace Watson.Web.Extensions
{
	public static class AppExtensions
	{
		public static void UseSwaggerExtension(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Watson.Web");
			});
		}

		public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}
}
