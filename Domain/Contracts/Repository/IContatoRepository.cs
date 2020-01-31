using Domain.Model;
using System;
using System.Collections.Generic;

namespace Domain.Contracts.Repository
{
    public interface IContatoRepository : IDisposable
    {
        Contato Get(Guid id);
        Contato Get(string email);
        List<Contato> Get(int skip, int take);
        void Create(Contato contato);
        void Delete(Contato contato);
       
    }
}
