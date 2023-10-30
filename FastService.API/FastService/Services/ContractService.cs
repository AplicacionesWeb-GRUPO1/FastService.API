using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Services;

public class ContractService : IContractService
{
    private readonly IContractRepository _contractRepository;
    private readonly IExpertRepository _expertRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ContractService(IContractRepository publicationRepository, IUnitOfWork unitOfWork, IExpertRepository expertRepository)
    {
        _contractRepository = publicationRepository;
        _unitOfWork = unitOfWork;
        _expertRepository = expertRepository;
    }

    public async Task<IEnumerable<Contract>> ListAsync()
    {
        return await _contractRepository.ListAsync();
    }

    public async Task<IEnumerable<Contract>> ListByExpertIdAsync(int expertId)
    {
        return await _contractRepository.FindByExpertIdAsync(expertId);
    }

    public async Task<ContractResponse> SaveAsync(Contract contract)
    {
        // Validate ExpertId

        var existingExpert = await _expertRepository.FindByIdAsync(contract.ExpertId);

        if (existingExpert == null)
            return new ContractResponse("Invalid Expert");
        
        try
        {
            // Add Contract
            await _contractRepository.AddAsync(contract);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new ContractResponse(contract);

        }
        catch (Exception e)
        {
            // Error Handling
            return new ContractResponse($"An error occurred while saving the contract: {e.Message}");
        }

        
    }

    public async Task<ContractResponse> UpdateAsync(int contractId, Contract contract)  
    {
        var existingContract = await _contractRepository.FindByIdAsync(contractId);
        
        // Validate Contract

        if (existingContract == null)
            return new ContractResponse("Contract not found.");

        // Validate ClientId

        var existingClient = await _expertRepository.FindByIdAsync(contract.ExpertId);

        if (existingClient == null)
            return new ContractResponse("Invalid Expert");
        
        // Modify Fields publicationId, ExpertId, price , state
        existingContract.PublicationId = contract.PublicationId;
        existingContract.ExpertId = contract.ExpertId;
        existingContract.Price = contract.Price;
        existingContract.State = contract.State;

        try
        {
            _contractRepository.Update(existingContract);
            await _unitOfWork.CompleteAsync();

            return new ContractResponse(existingContract);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ContractResponse($"An error occurred while updating the contract: {e.Message}");
        }

    }

    public async Task<ContractResponse> DeleteAsync(int contractId)
    {
        var existingContract = await _contractRepository.FindByIdAsync(contractId);
        
        // Validate Contract

        if (existingContract == null)
            return new ContractResponse("Contract not found.");
        
        try
        {
            _contractRepository.Remove(existingContract);
            await _unitOfWork.CompleteAsync();

            return new ContractResponse(existingContract);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new ContractResponse($"An error occurred while deleting the contract: {e.Message}");
        }

    }
}