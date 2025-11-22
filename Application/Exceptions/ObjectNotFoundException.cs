namespace Application.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string NomeObjeto { get; set; } = "Objeto";
        public long Id { get; }

        public ObjectNotFoundException(string nomeObjeto, long id)
            : base($"{nomeObjeto} com ID {id} não foi encontrado")
        {
            NomeObjeto = nomeObjeto;
            Id = id;
        }
    }
}
