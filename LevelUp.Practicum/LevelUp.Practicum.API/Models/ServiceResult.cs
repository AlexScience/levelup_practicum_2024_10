namespace LevelUp.Practicum.API.Models;

public record ServiceResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}