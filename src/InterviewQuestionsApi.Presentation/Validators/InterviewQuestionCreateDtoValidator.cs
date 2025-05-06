using FluentValidation;
using InterviewQuestionsApi.Application.DTOs;

namespace InterviewQuestionsApi.Presentation.Validators;

public class InterviewQuestionCreateDtoValidator : AbstractValidator<InterviewQuestionCreateDto>
{
    public InterviewQuestionCreateDtoValidator()
    {
        RuleFor(x => x.Question).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Answer).NotEmpty();
    }

}