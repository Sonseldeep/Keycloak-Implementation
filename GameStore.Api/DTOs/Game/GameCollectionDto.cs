namespace GameStore.Api.DTOs.Game;

public sealed record GameCollectionDto
{
    public List<GameDto>? Items { get; init; }
}