using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Services
{
    public interface IContatoService : IDisposable
    {
        Contato GetByEmail(string email);
        Contato Register(string nome, string telefone, string email, string endereco);
        List<Contato> GetByRange(int skip, int take);
        void Delete(string email);

    }
}
