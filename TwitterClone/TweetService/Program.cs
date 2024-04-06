using TweetService;
using EasyNetQ;
using TweetService.Core.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton(new MessageClient(RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualHost=/;username=guest;password=guest")));
builder.Services.AddScoped<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<ITweetService, TweetService.Core.Services.TweetService>();
builder.Services.AddDbContext<TweetContext>();
builder.Services.AddControllers();
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();