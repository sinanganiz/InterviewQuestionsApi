using InterviewQuestionsApi.Application.Repositories;
using InterviewQuestionsApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestionsApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InterviewQuestionsController : ControllerBase
{
    private readonly IInterviewQuestionRepository _repository;

    public InterviewQuestionsController(IInterviewQuestionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questions = await _repository.GetAllAsync();
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var question = await _repository.GetByIdAsync(id);
        return question is null ? NotFound() : Ok(question);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InterviewQuestion question)
    {
        await _repository.CreateAsync(question);
        return CreatedAtAction(nameof(GetById), new { id = question.Id }, question);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, InterviewQuestion question)
    {
        if (id != question.Id) return BadRequest();
        await _repository.UpdateAsync(question);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

}