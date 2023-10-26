using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _clientRepository.ListAsync();
    }

    public async Task<ClientResponse> SaveAsync(Client client)
    {
        try
        {
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(client);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while saving the client: {e.Message}");
        }
    }

    public async Task<ClientResponse> UpdateAsync(int id, Client category)
    {
        var existingCategory = await _clientRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new ClientResponse("Client not found.");

        existingCategory.Name = category.Name;

        try
        {
            _clientRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new ClientResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while updating the client: {e.Message}");
        }
    }

    public async Task<ClientResponse> DeleteAsync(int id)
    {
        var existingCategory = await _clientRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new ClientResponse("Client not found.");

        try
        {
            _clientRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new ClientResponse(existingCategory);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ClientResponse($"An error occurred while deleting the client: {e.Message}");
        }
    }
}