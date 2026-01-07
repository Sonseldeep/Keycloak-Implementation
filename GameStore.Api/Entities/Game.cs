namespace GameStore.Api.Entities;

public sealed class Game
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } =  string.Empty;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
}