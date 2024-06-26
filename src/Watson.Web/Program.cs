using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using Watson.Adapter.SqlServer;
using Watson.Adapter.SqlServer.Repositories;
using Watson.Adapter.Stub.Repositories;
using Watson.Application;
using Watson.Core.Ports;
using Watson.Web.Extensions;
using Watson.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceAdapter(builder.Configuration);
builder.Services.AddSwaggerExtension();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddControllers().AddJsonOptions(o =>
{
	o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	o.JsonSerializerOptions.IncludeFields = true;
});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());


bool useStubs = builder.Configuration.GetValue<bool>("UseStubs");

if (useStubs)
{
	builder.Services.AddTransient<INoteRepository, NoteRepositoryStub>();
}
else
{
	builder.Services.AddTransient<INoteRepository, NoteRepository>();
}

builder.Services.AddApiVersioningExtension();
builder.Services.AddVersioningPrefix();
builder.Services.AddHealthChecks();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwaggerExtension();
	app.UseHttpLogging();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

app.Run();

public partial class Program { }
