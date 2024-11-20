var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Addcustomjwtauthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
