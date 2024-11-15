using Jwtauthenticationmanager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Addcustomjwtauthentication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow requests from React app
              .AllowAnyHeader() // Allow all headers (e.g., Content-Type, Authorization)
              .AllowAnyMethod(); // Allow all HTTP methods (GET, POST, etc.)
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS policy
app.UseCors("AllowSpecificOrigin");


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
