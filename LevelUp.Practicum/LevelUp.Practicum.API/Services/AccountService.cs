using LevelUp.Practicum.API.CustomExceptions;
using LevelUp.Practicum.API.DataAccess;
using LevelUp.Practicum.API.Models;

namespace LevelUp.Practicum.API.Services;

public class AccountService(TicketsDbContext context) : IAccountService
{
    public Guid Create(Guid ownerId)
    {
        var passengerFound = context.Passengers.Any(p => p.Id == ownerId);
        if (!passengerFound)
        {
            throw new PassengerNotFoundException(ownerId);
        }

        var account = new Account(Guid.NewGuid(), ownerId);
        context.Accounts.Add(account);
        context.SaveChanges();

        return account.Id;
    }

    public IEnumerable<Account> GetAll()
    {
        return context.Accounts.ToList();
    }

    public ServiceResult TopUpAccount(Guid accountId, decimal amount)
    {
        var account = context.Accounts.Find(accountId);

        if (account == null)
        {
            throw new ArgumentException();
        }

        account.Balance += amount;
        context.SaveChanges();

        return new ServiceResult { Success = true, Message = $"Счёт успешно пополнен.\nБаланс: {account.Balance}" };
    }
}