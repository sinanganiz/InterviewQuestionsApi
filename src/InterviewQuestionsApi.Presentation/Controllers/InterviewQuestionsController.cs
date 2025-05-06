using AutoMapper;
using InterviewQuestionsApi.Application.Common.Responses;
using InterviewQuestionsApi.Application.DTOs;
using InterviewQuestionsApi.Application.Repositories;
using InterviewQuestionsApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestionsApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewQuestionsController : ControllerBase
{
    private readonly IInterviewQuestionRepository _repository;
    private readonly IMapper _mapper;

    public InterviewQuestionsController(IInterviewQuestionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<InterviewQuestionResponseDto>>>> GetAllAsync()
    {
        var questions = await _repository.GetAllAsync();
        if (questions is null)
            return NotFound(ApiResponse<List<InterviewQuestionResponseDto>>.Failure("Interview questions not found."));

        var dto = _mapper.Map<List<InterviewQuestionResponseDto>>(questions);
        return Ok(ApiResponse<List<InterviewQuestionResponseDto>>.SuccessResponse(dto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<InterviewQuestionResponseDto>>> GetByIdAsync(string id)
    {
        var question = await _repository.GetByIdAsync(id);
        if (question is null)
            return NotFound(ApiResponse<InterviewQuestionResponseDto>.Failure("Interview question not found."));

        var dto = _mapper.Map<InterviewQuestionResponseDto>(question);
        return Ok(ApiResponse<InterviewQuestionResponseDto>.SuccessResponse(dto));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<string>>> CreateAsync([FromBody] InterviewQuestionCreateDto dto)
    {
        var model = _mapper.Map<InterviewQuestion>(dto);
        await _repository.CreateAsync(model);

        return Ok(ApiResponse<string>.SuccessResponse(model.Id, "Interview question created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<string>>> UpdateAsync(string id, [FromBody] InterviewQuestionUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return NotFound(ApiResponse<string>.Failure("Interview question not found."));

        _mapper.Map(dto, existing);
        await _repository.UpdateAsync(existing);

        return Ok(ApiResponse<string>.SuccessResponse(existing.Id, "Interview question updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<string>>> DeleteAsync(string id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return NotFound(ApiResponse<string>.Failure("Interview question not found."));

        await _repository.DeleteAsync(id);

        return Ok(ApiResponse<string>.SuccessResponse(id, "Interview question deleted successfully."));
    }

}