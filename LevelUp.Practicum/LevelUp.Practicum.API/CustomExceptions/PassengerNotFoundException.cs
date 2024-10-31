namespace LevelUp.Practicum.API.CustomExceptions;

public class PassengerNotFoundException(Guid id) : System.Exception($"Passenger with id {id} not found");