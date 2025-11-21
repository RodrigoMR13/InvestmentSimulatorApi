namespace Application.Interfaces
{
    public interface ITimeProvider
    {
        DateTimeOffset UtcNow { get; }
        DateTimeOffset BrazilNow { get; }
    }
}
