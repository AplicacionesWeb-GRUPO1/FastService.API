using AutoMapper;
using FastService.API.Security.Domain.Models;
using FastService.API.Security.Domain.Repositories;
using FastService.API.Security.Domain.Services.Communication;
using FastService.API.Security.Resources;
using FastService.API.Security.Authorization.Attributes;
using FastService.API.FastService.Domain.Models;


using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using FastService.API.FastService.Domain.Services;

namespace FastService.API.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IClientService _clientService;
    private readonly IExpertService _expertService;

    private readonly IMapper _mapper;
    public UsersController(IUserService userService, IClientService ClientService, IExpertService ExpertService, IMapper mapper)
    {
        _userService = userService;
        _clientService = ClientService;
        _expertService = ExpertService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);

        if (request.Role == "client"){
            var newClient = new Client
            {
                Name = request.UserName,
                LastName = request.UserName,
                Phone = request.Phone,
                BirthdayDate = request.BirthdayDate,
                Money = 300,
                Avatar = "https://picsum.photos/200/300",
                Role = request.Role,
            };

            var result = await _clientService.SaveAsync(newClient);
            return Ok(new { message = result });
        }
        ////else if (request.Role == "client") {}
        var newExpert = new Expert
        {
            Name = request.UserName,
            LastName = request.UserName,
            Phone = request.Phone,
            BirthdayDate = request.BirthdayDate,
            Money = 300,
            Rating = 5,
            specialty = "jardinero",
            Avatar = "https://picsum.photos/200/300",
            Role = request.Role,
        }; 
        var resultExper = await _expertService.SaveAsync(newExpert);
        return Ok(new { message = resultExper });

    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>,
            IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }

}