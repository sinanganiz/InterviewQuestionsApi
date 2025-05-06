using InterviewQuestionsApi.Domain.Entities;

namespace InterviewQuestionsApi.Application.Repositories;

public interface IInterviewQuestionRepository
{
    Task<List<InterviewQuestion>> GetAllAsync();
    Task<InterviewQuestion?> GetByIdAsync(string id);
    Task CreateAsync(InterviewQuestion question);
    Task UpdateAsync(InterviewQuestion question);
    Task DeleteAsync(string id);

}