namespace Server.Models;

public interface IHasUrl
{
    int Id { get; set; }
    string? Url { get; set; }
}
