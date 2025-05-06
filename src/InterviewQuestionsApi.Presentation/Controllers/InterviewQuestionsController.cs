using AutoMapper;
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
    public async Task<IActionResult> GetAllAsync()
    {
        var questions = await _repository.GetAllAsync();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(string id)
    {
        var question = await _repository.GetByIdAsync(id);
        return question is null ? NotFound() : Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] InterviewQuestionCreateDto dto)
    {
        var model = _mapper.Map<InterviewQuestion>(dto);
        await _repository.CreateAsync(model);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = model.Id }, _mapper.Map<InterviewQuestionResponseDto>(model));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] InterviewQuestionUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return NotFound();

        _mapper.Map(dto, existing);

        await _repository.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

}