using AutoMapper;
using TimelineService.DTO;
using TimelineService.Mappers;
using TimelineService.Models;
using TimelineService.Repository;
using TimelineService.Repository.Models;
using TimelineService.Service;

MongoDbMapping.RegisterClassMaps();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TimelineDatabaseSettings>(
    builder.Configuration.GetSection("TimelineDatabase"));

builder.Services.AddSingleton<ITimelineRepository, TimelineRepository>();
builder.Services.AddSingleton<ITimelineDataService, TimelineDataService>();

var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<Tweet, TweetResponseDto>();
    configuration.CreateMap<Timeline, TimelineResponseDto>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();