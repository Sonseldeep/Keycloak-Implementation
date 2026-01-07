namespace GameStore.Api.DTOs.Game;

public sealed record CreateGameDto
{
    public string Name { get; init; }
    public string Genre { get; init; }
    public decimal Price { get; init; }
    public DateTime ReleaseDate { get; init; }
}