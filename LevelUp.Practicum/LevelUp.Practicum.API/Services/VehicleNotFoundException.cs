namespace LevelUp.Practicum.API.Services;

public class VehicleNotFoundException(Guid id) : Exception($"Vehicle with id {id} not found");