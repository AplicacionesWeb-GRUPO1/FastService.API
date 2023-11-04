using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Resources;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FastService.API.FastService.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class GalleriesController : ControllerBase
{
    private readonly IGalleryService _galleryService;
    private readonly IMapper _mapper;

    public GalleriesController(IGalleryService galleryService, IMapper mapper)
    {
        _galleryService = galleryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<GalleryResource>> GetAllAsync()
    {
        var Gallerys = await _galleryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Gallery>, IEnumerable<GalleryResource>>(Gallerys);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveGalleryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var gallery =  _mapper.Map<SaveGalleryResource,Gallery>(resource);

        var result = await _galleryService.SaveAsync(gallery);

        if (!result.Success)
            return BadRequest(result.Message);

        var galleryResource = _mapper.Map<Gallery, GalleryResource>(result.Resource);

        return Ok(galleryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGalleryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var Gallery = _mapper.Map<SaveGalleryResource, Gallery>(resource);

        var result = await _galleryService.UpdateAsync(id, Gallery);

        if (!result.Success)
            return BadRequest(result.Message);

        var GalleryResource = _mapper.Map<Gallery, GalleryResource>(result.Resource);

        return Ok(GalleryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _galleryService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var GalleryResource = _mapper.Map<Gallery, GalleryResource>(result.Resource);

        return Ok(GalleryResource);
    }

}