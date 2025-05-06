using AutoMapper;
using InterviewQuestionsApi.Application.DTOs;
using InterviewQuestionsApi.Domain.Entities;

namespace InterviewQuestionsApi.Application.Mappings;

public class InterviewQuestionProfile : Profile
{
    public InterviewQuestionProfile()
    {
        CreateMap<InterviewQuestion, InterviewQuestionResponseDto>();
        CreateMap<InterviewQuestionCreateDto, InterviewQuestion>();
        CreateMap<InterviewQuestionUpdateDto, InterviewQuestion>();
    }
}