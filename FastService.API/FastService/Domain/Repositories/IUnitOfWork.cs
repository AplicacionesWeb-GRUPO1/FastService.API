namespace FastService.API.FastService.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}