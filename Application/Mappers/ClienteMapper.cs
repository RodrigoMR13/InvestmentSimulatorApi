using Application.Responses;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteResponse ToClienteResponse(this Cliente entity)
        {
            return new ClienteResponse
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email,
                DataCadastro = entity.DataCadastro
            };
        }
    }
}
