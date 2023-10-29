using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Resources;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FastService.API.FastService.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;
    

    public ClientsController(IClientService clientService, IMapper mapper)
    {
        _clientService = clientService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ClientResource>> GetAllAsync()
    {
        var clients = await _clientService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>> (clients);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var client = _mapper.Map<SaveClientResource, Client>(resource);

        var result = await _clientService.SaveAsync(client);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

        return Ok(clientResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClientResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var client = _mapper.Map<SaveClientResource, Client>(resource);
        var result = await _clientService.UpdateAsync(id, client);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

        return Ok(clientResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _clientService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);

        return Ok(clientResource);
    }
    
}