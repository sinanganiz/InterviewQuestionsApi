using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using InterviewQuestionsApi.Infrastructure.Configurations;
using MongoDB.Driver;
using InterviewQuestionsApi.Application.Repositories;
using InterviewQuestionsApi.Infrastructure.Repositories;

namespace InterviewQuestionsApi.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbOptions>(configuration.GetSection("MongoDbOptions"));

        services.AddSingleton<IMongoClient>(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoDbOptions>>().Value;
            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped(sp =>
        {
            var options = sp.GetRequiredService<IOptions<MongoDbOptions>>().Value;
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(options.DatabaseName);
        });

        services.AddScoped<IInterviewQuestionRepository, InterviewQuestionRepository>();

        return services;
    }
}