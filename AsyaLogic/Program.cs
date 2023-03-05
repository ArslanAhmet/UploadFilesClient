using AsyaLogic.Core.MapServices;
using AsyaLogic.Core.ObjectMapper;
using AsyaLogic.Infrastructure.Data;
using AsyaLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.AddDbContext<AsyaLogicContext>(opts => opts.UseSqlServer(builder.Configuration["sqlconnection:connectionString"]));
builder.Services.AddTransient<IFileUploadService, FileUploadLocalService>();
builder.Services.AddScoped<IEventRecordRepository, EventRecordRepository>();
builder.Services.AddScoped<IEventRecordMapService, EventRecordMapService>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder.WithOrigins(
    "http://localhost",
    "http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
