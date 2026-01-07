using GameStore.Api.DTOs.Game;
using GameStore.Api.Mappings;
using GameStore.Api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controller;

[ApiController]
[Route("api/games")]
public class GameController(IGameRepository gameRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
    {
        var games = await gameRepository
            .GetAllAsync(cancellationToken);
        var gameCollectionDto = new GameCollectionDto
        {
            Items = games.Select(g => g.ToDto()).ToList(),
        };
        return Ok(gameCollectionDto);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id,CancellationToken cancellationToken)
    {
        var game = await gameRepository
            .GetByIdAsync(id,cancellationToken);
        if (game is null)
        {
            return NotFound();
        }
        var gameDto = game.ToDto();
        return Ok(gameDto);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateGameDto dto,CancellationToken cancellationToken)
    {
        var game = dto.ToEntity();
        await gameRepository
            .AddAsync(game,cancellationToken);
        var gameDto = game.ToDto();
        return CreatedAtAction(nameof(GetById),
            new { id = game.Id },
            gameDto);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] string id,
        [FromBody] UpdateGameDto dto,CancellationToken cancellationToken)
    {
        var game = await gameRepository
            .GetByIdAsync(id,cancellationToken);
        if (game is null)
        {
            return NotFound();
        }
        game.UpdateFromDto(dto);
        await gameRepository
            .UpdateAsync(game, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] string id,CancellationToken cancellationToken)
    {
        var game = await gameRepository
            .GetByIdAsync(id,cancellationToken);
        if (game is null)
        {
            return NotFound();
        }
        await gameRepository
            .DeleteAsync(game,cancellationToken);
        return NoContent();
    }
}