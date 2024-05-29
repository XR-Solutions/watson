using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using Watson.Adapter.SqlServer;
using Watson.Adapter.SqlServer.Repositories;
using Watson.Application;
using Watson.Core.Ports;
using Watson.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceAdapter(builder.Configuration);
builder.Services.AddSwaggerExtension();

builder.Services.AddControllers().AddJsonOptions(o =>
	o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//builder.Services.AddMediatR(cfg =>
//	 cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddTransient<INoteRepository, NoteRepository>();

// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateNoteCommandHandler>());




builder.Services.AddApiVersioningExtension();
builder.Services.AddVersioningPrefix();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwaggerExtension();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();

public partial class Program { }
