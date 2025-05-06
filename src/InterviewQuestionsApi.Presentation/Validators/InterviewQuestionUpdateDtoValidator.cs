using FluentValidation;
using InterviewQuestionsApi.Application.DTOs;

namespace InterviewQuestionsApi.Presentation.Validators;

public class InterviewQuestionUpdateDtoValidator : AbstractValidator<InterviewQuestionUpdateDto>
{
    public InterviewQuestionUpdateDtoValidator()
    {
        RuleFor(x => x.Question).NotEmpty().MaximumLength(150);
        RuleFor(x => x.Answer).NotEmpty();
    }
}