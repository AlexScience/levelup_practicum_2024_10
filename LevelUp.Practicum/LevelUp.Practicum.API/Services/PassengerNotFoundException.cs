namespace LevelUp.Practicum.API.Services;

public class PassengerNotFoundException(Guid id) : Exception($"Passenger with id {id} not found");