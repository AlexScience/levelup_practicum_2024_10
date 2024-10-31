namespace LevelUp.Practicum.API.CustomExceptions;

public class VehicleNotFoundException(Guid id) : System.Exception($"Vehicle with id {id} not found");