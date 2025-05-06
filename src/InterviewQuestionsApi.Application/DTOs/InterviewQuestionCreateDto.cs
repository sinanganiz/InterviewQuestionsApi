namespace InterviewQuestionsApi.Application.DTOs;

public class InterviewQuestionCreateDto
{
    public string Question { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public List<string>? Tags { get; set; }
    public string Difficulty { get; set; } = null!;
}