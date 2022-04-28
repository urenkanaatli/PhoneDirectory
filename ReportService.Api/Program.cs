
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Base.Enums;
using EventBus.Factory;
using ReportService.Application;
using ReportService.Application.Operations.Reports.IntegrationEvents;
using ReportService.Insfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrasturucture(builder.Configuration);


builder.Services.AddTransient<NewReportAddedIntegrationEventHendler, NewReportAddedIntegrationEventHendler>();

builder.Services.AddSingleton<IEventBus>((sp) =>
{

    EventBusConfig eventBusConfig = new EventBusConfig
    {

        ConnectionRetryCount = 4,
        SubscriberClientAppName = "EventBus.Test",
        DefaultTopicName = "MyTopic",
        EventBusType = EventBusType.RabbitMQ,
        EventNameSuffix = "IntegerationEvent"

    };
    return EventBusFactory.Create(eventBusConfig, sp);
});



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
