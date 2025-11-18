using Program01.BusinessLogic;
using Program01.InterfaceClass;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. which means add singleton services to the application

builder.Services.AddSingleton<ILogInfo,LogInfo>();
builder.Services.AddSingleton<IStudentDetailsBL,StudentDetailsBL>();
 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding React js services called CROS services
/// Enabling CORS for React js application
builder.Services.AddCors(options =>
{ 
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// Enabling CORS for React js application
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
