using Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Infraestructure.Data.Map
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contatos");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome)
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Telefone)
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.Endereco)
                .HasMaxLength(220)
                .IsOptional();
            Property(x => x.Email)
                .HasMaxLength(160)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true }))
                .IsRequired();
            
        }
    }
}
