using AutoMapper;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.Security.Domain.Models;
using FastService.API.Security.Domain.Repositories;
using FastService.API.Security.Domain.Services.Communication;
using FastService.API.Security.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace FastService.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        // validate
        if (_userRepository.ExistsByUsername(request.UserName))
            throw new AppException("Username '" + request.UserName + "' is already taken");
        // map model to new user object
        var user = _mapper.Map<User>(request);
        // hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        // save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
    
    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        // Validate
        if (_userRepository.ExistsByUsername(request.UserName))
            throw new AppException("Username '" + request.UserName + "' is already taken");
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        // Copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);

        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }
}