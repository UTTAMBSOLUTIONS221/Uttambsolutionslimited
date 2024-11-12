using Jwtauthenticationmanager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Addcustomjwtauthentication();
//Database configuration 
//var Dbhost = Environment.GetEnvironmentVariable("DB_HOST");
//var Dbname = Environment.GetEnvironmentVariable("DB_NAME");
//var Dbusername = Environment.GetEnvironmentVariable("DB_USERNAME");
//var Dbpassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var Connectionstring = $"Data Source={Dbhost};Database={Dbname};User Id={Dbusername};Password={Dbusername};TrustServerCertificate=true";
//builder.Services.AddDbContext<Staff>

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
