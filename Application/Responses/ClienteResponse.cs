namespace Application.Responses
{
    public class ClienteResponse
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTimeOffset DataCadastro { get; set; }
    }
}
