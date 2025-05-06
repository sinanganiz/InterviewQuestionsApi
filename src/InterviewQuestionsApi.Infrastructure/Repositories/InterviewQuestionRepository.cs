using InterviewQuestionsApi.Application.Repositories;
using InterviewQuestionsApi.Domain.Entities;
using MongoDB.Driver;

namespace InterviewQuestionsApi.Infrastructure.Repositories;

public class InterviewQuestionRepository : IInterviewQuestionRepository
{
    private readonly IMongoCollection<InterviewQuestion> _collection;

    public InterviewQuestionRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<InterviewQuestion>("interview_questions");
    }

    public async Task<List<InterviewQuestion>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<InterviewQuestion?> GetByIdAsync(string id) =>
        await _collection.Find(q => q.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(InterviewQuestion question) =>
        await _collection.InsertOneAsync(question);

    public async Task UpdateAsync(InterviewQuestion question) =>
        await _collection.ReplaceOneAsync(q => q.Id == question.Id, question);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(q => q.Id == id);

}