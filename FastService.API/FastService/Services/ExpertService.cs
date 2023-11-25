using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Services;

public class ExpertService : IExpertService
{
    private readonly IExpertRepository _expertRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExpertService(IExpertRepository expertRepository, IUnitOfWork unitOfWork)
    {
        _expertRepository = expertRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Expert>> ListAsync()
    {
        return await _expertRepository.ListAsync();
    }

    public async Task<ExpertResponse> GetByIdAsync(int id)
    {
        var existingExpert = await _expertRepository.FindByIdAsync(id);

        if (existingExpert == null)
            return new ExpertResponse("Expert not found.");
        return new ExpertResponse(existingExpert);
    }

    public async Task<ExpertResponse> GetByUserNameAsync(string userName) {
        var existingExpert = await _expertRepository.FindByUserNameAsync(userName);
        if (existingExpert == null)
            return new ExpertResponse("Expert not found.");
        return new ExpertResponse(existingExpert);
    }

    public async Task<ExpertResponse> SaveAsync(Expert expert)
    {
        try
        {
            await _expertRepository.AddAsync(expert);
            await _unitOfWork.CompleteAsync();
            return new ExpertResponse(expert);
        }
        catch (Exception e)
        {
            return new ExpertResponse($"An error occurred while saving the expert: {e.Message}");
        }
    }

    public async Task<ExpertResponse> UpdateAsync(int id, Expert expert)
    {
        var existingExpert = await _expertRepository.FindByIdAsync(id);

        if (existingExpert == null)
            return new ExpertResponse("Expert not found.");

        existingExpert.Name = expert.Name;
        existingExpert.LastName = expert.LastName;
        existingExpert.Phone = expert.Phone;
        existingExpert.BirthdayDate = expert.BirthdayDate;
        existingExpert.Money = expert.Money;
        existingExpert.Rating = expert.Rating;
        existingExpert.Avatar = expert.Avatar;
        existingExpert.Role = expert.Role;

        try
        {
            _expertRepository.Update(existingExpert);
            await _unitOfWork.CompleteAsync();

            return new ExpertResponse(existingExpert);
        }
        catch (Exception e)
        {
            return new ExpertResponse($"An error occurred while updating the expert: {e.Message}");
        }
    }

    public async Task<ExpertResponse> DeleteAsync(int id)
    {
        var existingExpert = await _expertRepository.FindByIdAsync(id);

        if (existingExpert == null)
            return new ExpertResponse("Expert not found.");

        try
        {
            _expertRepository.Remove(existingExpert);
            await _unitOfWork.CompleteAsync();

            return new ExpertResponse(existingExpert);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ExpertResponse($"An error occurred while deleting the expert: {e.Message}");
        }
    }
}