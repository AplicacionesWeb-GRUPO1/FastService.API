﻿using AutoMapper;
using FastService.API.Learning.Domain.Models;
using FastService.API.Learning.Domain.Services;
using FastService.API.Learning.Resources;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FastService.API.FastService.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PublicationsController : ControllerBase
{
    private readonly IPublicationService _tutorialService;
    private readonly IMapper _mapper;

    public PublicationsController(IPublicationService tutorialService, IMapper mapper)
    {
        _tutorialService = tutorialService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TutorialResource>> GetAllAsync()
    {
        var tutorials = await _tutorialService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tutorial>, IEnumerable<TutorialResource>>(tutorials);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTutorialResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tutorial = _mapper.Map<SaveTutorialResource, Tutorial>(resource);

        var result = await _tutorialService.SaveAsync(tutorial);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Tutorial, TutorialResource>(result.Resource);

        return Ok(tutorialResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTutorialResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tutorial = _mapper.Map<SaveTutorialResource, Tutorial>(resource);

        var result = await _tutorialService.UpdateAsync(id, tutorial);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Tutorial, TutorialResource>(result.Resource);

        return Ok(tutorialResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tutorialService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Tutorial, TutorialResource>(result.Resource);

        return Ok(tutorialResource);
    }

}