using Watson.Web.Extensions;
using Watson.Application;
using Watson.Adapter.SqlServer;
using Watson.Adapter.Shared;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddApplicationLayer();
builder.Services.AddSharedAdapter();
builder.Services.AddPersistenceAdapter(builder.Configuration);
builder.Services.AddSwaggerExtension();

builder.Services.AddControllers().AddJsonOptions(o =>
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
