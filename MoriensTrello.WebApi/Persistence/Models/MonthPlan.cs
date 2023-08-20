namespace MoriensTrello.WebApi.Persistence.Models;

public class MonthPlan {
    public Guid Id { get; init; }
    public int? Day { get; init; }
    public int? Amount { get; init; }
    public string? Direction { get; init; }
    public string? Name { get; init; }
}