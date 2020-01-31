using Common.Resources;
using Common.Validation;
using System;

namespace Domain.Model
{
    public class Contato
    {
        #region construtor
        protected Contato()
        {
        }
        public Contato(string nome, string email, string endereco, string telefone)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Telefone = telefone;
            this.Endereco = endereco;
            this.Email = email;
        }
        #endregion
        #region propriedades
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        #endregion
        #region metodos
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.Nome, Errors.NomeEmBranco);
            AssertionConcern.AssertArgumentNotNull(this.Telefone, Errors.TelefoneEmBranco);
            AssertionConcern.AssertArgumentNotNull(this.Email, Errors.EmailEmBranco);
            EmailAssertionConcern.AssertIsValid(this.Email, Errors.EmailInvalido);
            TelefoneAssertionConcern.AssertIsValid(this.Telefone, Errors.TelefoneInvalido);


        }
        #endregion
    }
}
