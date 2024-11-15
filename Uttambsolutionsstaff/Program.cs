using Jwtauthenticationmanager;

var builder = WebApplication.CreateBuilder(args);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Replace with your frontend's origin
              .AllowAnyHeader()                     // Allow all headers
              .AllowAnyMethod();                    // Allow all HTTP methods
    });
});

builder.Services.AddControllers();
builder.Services.Addcustomjwtauthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Enable the CORS policy
app.UseCors("AllowReactApp");

app.UseAuthorization();
app.MapControllers();
app.Run();
