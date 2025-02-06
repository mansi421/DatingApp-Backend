using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// to make progam.cs cleaner, we can move the services to the extensions folder.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

 // configure the http request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
.WithOrigins("https://localhost:4200", "http://localhost:4200"));
app.MapControllers();

app.Run();
