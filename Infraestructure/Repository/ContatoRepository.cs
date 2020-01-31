using Domain.Contracts.Repository;
using Domain.Model;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private AppDataContext dataContext;

        public ContatoRepository(AppDataContext context)
        {
            this.dataContext = context;
        }
        public Contato Get(Guid id)
        {
            return dataContext.Contacts.Where(x => x.Id == id).FirstOrDefault();
        }
        public Contato Get(string email)
        {
            return dataContext.Contacts.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public void Create(Contato contato)
        {
            dataContext.Contacts.Add(contato);
            dataContext.SaveChanges();
        }
        public void Delete(Contato contato)
        {
            dataContext.Contacts.Remove(contato);
            dataContext.SaveChanges();
        }
        public List<Contato> Get(int skip, int take)
        {
            return dataContext.Contacts.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
