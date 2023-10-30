using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Resources;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FastService.API.FastService.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ContractController : ControllerBase
{
    private readonly IContractService _contractService;
    private readonly IMapper _mapper;

    public ContractController(IContractService contractService, IMapper mapper)
    {
        _contractService = contractService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ContractResource>> GetAllAsync()
    {
        var publications = await _contractService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractResource>>(publications);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveContractResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var publication =  _mapper.Map<SaveContractResource, Contract>(resource);

        var result = await _contractService.SaveAsync(publication);

        if (!result.Success)
            return BadRequest(result.Message);

        var ContractResource = _mapper.Map<Contract, ContractResource>(result.Resource);

        return Ok(ContractResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContractResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var publication = _mapper.Map<SaveContractResource, Contract>(resource);

        var result = await _contractService.UpdateAsync(id, publication);

        if (!result.Success)
            return BadRequest(result.Message);

        var ContractResource = _mapper.Map<Contract, ContractResource>(result.Resource);

        return Ok(ContractResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _contractService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var ContractResource = _mapper.Map<Contract, ContractResource>(result.Resource);

        return Ok(ContractResource);
    }

}