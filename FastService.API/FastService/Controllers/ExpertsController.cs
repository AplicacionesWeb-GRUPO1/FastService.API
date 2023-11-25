using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Resources;
using FastService.API.FastService.Services;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FastService.API.FastService.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ExpertsController : ControllerBase
{
    private readonly IExpertService _expertService;
    private readonly IMapper _mapper;
    

    public ExpertsController(IExpertService expertService, IMapper mapper)
    {
        _expertService = expertService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ExpertResource>> GetAllAsync()
    {
        var experts = await _expertService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Expert>, IEnumerable<ExpertResource>> (experts);

        return resources;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var expert = await _expertService.GetByIdAsync(id);
        var result = _mapper.Map<Expert, ExpertResource>(expert.Resource);
        return Ok(result);

    }

    [HttpGet("GetByUsername/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var expert = await _expertService.GetByUserNameAsync(username);
        var result = _mapper.Map<Expert, ExpertResource>(expert.Resource);
        return Ok(result);

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveExpertResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var expert = _mapper.Map<SaveExpertResource, Expert>(resource);

        var result = await _expertService.SaveAsync(expert);

        if (!result.Success)
            return BadRequest(result.Message);

        var ExpertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);

        return Ok(ExpertResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveExpertResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var expert = _mapper.Map<SaveExpertResource, Expert>(resource);
        var result = await _expertService.UpdateAsync(id, expert);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var ExpertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);

        return Ok(ExpertResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _expertService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var ExpertResource = _mapper.Map<Expert, ExpertResource>(result.Resource);

        return Ok(ExpertResource);
    }
    
}