using Common.Resources;
using Domain.Contracts.Repository;
using Domain.Contracts.Services;
using Domain.Model;
using System;
using System.Collections.Generic;

namespace Busines.Services
{
    public class ContatoService : IContatoService
    {
        private IContatoRepository contatoRepository;
        public ContatoService(IContatoRepository repository)
        {
            this.contatoRepository = repository;
        }
        public Contato GetByEmail(string email)
        {
            var contato = contatoRepository.Get(email);
            if (email == null)
                throw new Exception(Errors.ContatoInvalido);

            return contato;
        }
        public Contato Register(string nome, string email, string endereco, string telefone)
        {
            var hasContato = contatoRepository.Get(email);
            if (hasContato != null)
                throw new Exception(Errors.EmailDuplicado);

            var contato = new Contato(nome, email, endereco, telefone);
            contato.Validate();

            contatoRepository.Create(contato);
            return this.GetByEmail(email);
        }
        public List<Contato> GetByRange(int skip, int take)
        {
            return contatoRepository.Get(skip, take);
        }
        public void Delete(string id)
        {
            var uid = Guid.Parse(id);
            var contato = contatoRepository.Get(uid);
            if (contato == null)
                throw new Exception(Errors.ContatoInvalido);

            contatoRepository.Delete(contato);
        }
        public void Dispose()
        {
            contatoRepository.Dispose();
        }


    }
}
