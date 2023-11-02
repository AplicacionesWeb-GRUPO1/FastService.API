using FastService.API.FastService.Domain.Models;
using FastService.API.FastService.Domain.Repositories;
using FastService.API.FastService.Domain.Services;
using FastService.API.FastService.Domain.Services.Communication;

namespace FastService.API.FastService.Services;

public class PublicationService : IPublicationService
{
    private readonly IPublicationRepository _publicationRepository;
    private readonly IClientRepository _clientRepository;

    private readonly IUnitOfWork _unitOfWork;

    public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IClientRepository clientRepository)
    {
        _publicationRepository = publicationRepository;
        _unitOfWork = unitOfWork;
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Publication>> ListAsync()
    {
        return await _publicationRepository.ListAsync();
    }

    public async Task<IEnumerable<Publication>> ListByClientIdAsync(int clientId)
    {
        return await _publicationRepository.FindByClientIdAsync(clientId);
    }

    public async Task<PublicationResponse> SaveAsync(Publication publication)
    {
        // Validate Client Id

        var existingClient = await _clientRepository.FindByIdAsync(publication.ClientId);

        if (existingClient == null)
            return new PublicationResponse("Invalid Client");
        
        // Validate titulo

        var existingTutorialWithTitle = await _publicationRepository.FindByTitleAsync(publication.Title);

        if (existingTutorialWithTitle != null)
            return new PublicationResponse("Publication title already exists.");

        try
        {
            // Add Publication
            await _publicationRepository.AddAsync(publication);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new PublicationResponse(publication);

        }
        catch (Exception e)
        {
            // Error Handling
            return new PublicationResponse($"An error occurred while saving the publication: {e.Message}");
        }

        
    }

    public async Task<PublicationResponse> UpdateAsync(int publicationId, Publication publication)  
    {
        var existingPublication = await _publicationRepository.FindByIdAsync(publicationId);
        
        // Validate Publication

        if (existingPublication == null)
            return new PublicationResponse("Publication not found.");

        // Validate ClientId

        var existingClient = await _clientRepository.FindByIdAsync(publication.ClientId);

        if (existingClient == null)
            return new PublicationResponse("Invalid Client");
        
        // Validate Title

        var existingPublicationWithTitle = await _publicationRepository.FindByTitleAsync(publication.Title);

        if (existingPublicationWithTitle != null && existingPublicationWithTitle.Id != existingPublication.Id)
            return new PublicationResponse("Publication title already exists.");

        // Modify Fields
        existingPublication.Address = publication.Address;
        existingPublication.Title = publication.Title;
        existingPublication.Description = publication.Description;
        existingPublication.IsPublished = publication.IsPublished;

        try
        {
            _publicationRepository.Update(existingPublication);
            await _unitOfWork.CompleteAsync();

            return new PublicationResponse(existingPublication);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new PublicationResponse($"An error occurred while updating the publication: {e.Message}");
        }

    }

    public async Task<PublicationResponse> DeleteAsync(int publicationId)
    {
        var existingPublication = await _publicationRepository.FindByIdAsync(publicationId);
        
        // Validate Publication

        if (existingPublication == null)
            return new PublicationResponse("Publication not found.");
        
        try
        {
            _publicationRepository.Remove(existingPublication);
            await _unitOfWork.CompleteAsync();

            return new PublicationResponse(existingPublication);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new PublicationResponse($"An error occurred while deleting the publication: {e.Message}");
        }

    }
}