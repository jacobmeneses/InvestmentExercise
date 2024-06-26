using InvestmentExercise.Data;
using InvestmentExercise.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<InvestmentService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OportunityService>();
builder.Services.AddSqlite<InvestmentExerciseContext>("Data Source=InvestmentExercise.db");

builder.Services.AddLogging(config =>
{
    config.AddConsole(); // Enable logging to the console
    config.AddDebug(); // Optional: Enable logging to the debug output
});

// TODO: "AllowAllOrigins" only on dev
builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
            builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.CreateDbIfNotExists();

// Enable CORS
app.UseCors("AllowAllOrigins");

app.Run();
