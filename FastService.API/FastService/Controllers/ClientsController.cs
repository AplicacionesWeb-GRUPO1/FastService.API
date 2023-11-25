using AutoMapper;
using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Domain.Services.Communication;
using FastService.API.FastService.Resources;
using FastService.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Xunit;
using Moq;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await _clientService.GetByIdAsync(id);
        var result = _mapper.Map<Client, ClientResource>(client.Resource);
        return Ok(result);

    }

    [HttpGet("GetByUsername/{username}")]
    public async Task<IActionResult> GetByUsername(string username)
    {
        var client = await _clientService.GetByUserNameAsync(username);
        var result = _mapper.Map<Client, ClientResource>(client.Resource);
        return Ok(result);
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
public class ClientsControllerTests
{
    private readonly Mock<IClientService> _mockClientService;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ClientsController _controller;

    public ClientsControllerTests()
    {
        _mockClientService = new Mock<IClientService>();
        _mockMapper = new Mock<IMapper>();
        _controller = new ClientsController(_mockClientService.Object, _mockMapper.Object);
    }
    [Fact]
    public async Task GetByUsername_ValidUsername_ReturnsOkObjectResult()
    {
        // Arrange
        var username = "testuser";
        var client = new Client(); // Simular un objeto Client
        var clientResource = new ClientResource(); // Simular un objeto ClientResource

        _mockClientService.Setup(x => x.GetByUsernameAsync(username))
            .ReturnsAsync(new ClientResponse(client));

        _mockMapper.Setup(x => x.Map<Client, ClientResource>(client))
            .Returns(clientResource);

        // Act
        var result = await _controller.GetByUsername(username);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.Equal(clientResource, okResult.Value);
    }
}
