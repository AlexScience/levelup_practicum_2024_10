namespace LevelUp.Practicum.API.Services;

public interface ITicketsService
{
    Guid Create(Guid ownerId);
}