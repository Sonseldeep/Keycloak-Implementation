using GameStore.Api.DTOs.Game;
using GameStore.Api.Entities;

namespace GameStore.Api.Mappings;

public static class GameMappings
{
    public static GameDto ToDto(this Game game)
    {
        return new GameDto
        {
            Id = game.Id,
            Name = game.Name,
            Genre = game.Genre,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,

        };
    }

    public static Game ToEntity(this CreateGameDto dto)
    {
        return new Game
        {
            Id = $"g_{Guid.NewGuid()}",
            Name = dto.Name,
            Genre = dto.Genre,
            Price = dto.Price,
            ReleaseDate = dto.ReleaseDate,
        };
    }

    public static void UpdateFromDto(this Game game, UpdateGameDto dto)
    {
        game.Name = dto.Name;
        game.Genre = dto.Genre;
        game.Price = dto.Price;
        game.ReleaseDate = dto.ReleaseDate;
    }
}