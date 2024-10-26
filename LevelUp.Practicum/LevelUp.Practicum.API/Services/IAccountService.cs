using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public interface IAccountService
{
    public Guid Create(Guid ownerId);

    public IEnumerable<Account> GetAll();

    public ServiceResult TopUpAccount(Guid accountId,decimal amount);
}