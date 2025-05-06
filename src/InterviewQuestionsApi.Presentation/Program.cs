using FluentValidation;
using FluentValidation.AspNetCore;
using InterviewQuestionsApi.Application.Mappings;
using InterviewQuestionsApi.Infrastructure;
using InterviewQuestionsApi.Presentation.Middleware;
using InterviewQuestionsApi.Presentation.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddMongoDb(builder.Configuration);

builder.Services.AddValidatorsFromAssemblyContaining<InterviewQuestionCreateDtoValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(typeof(InterviewQuestionProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();