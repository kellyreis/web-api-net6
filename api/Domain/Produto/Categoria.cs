using Flunt.Validations;

namespace api.Domain.Produto
{
    public class Categoria : Entity
    {
        public bool Active { get; private set; }

        public Categoria(string Nome, string CreatedBy, string EditedBy)
        {

            Nome = Nome;
            Active = true;
            CreatedBy = CreatedBy;
            CreatedOn = DateTime.Now;
            EditedBy = EditedBy;
            EditedOn = DateTime.Now;

            Validate();

        }
        public void Validate()
        {
            var contract = new Contract<Categoria>()
        .IsNotNullOrEmpty(Nome, "Nome", "Nome é obrigatorio")
    .IsNotNullOrEmpty(CreatedBy, "CreatedBy")
    .IsNotNullOrEmpty(EditedBy, "EditedBy");
            AddNotifications(contract);
        }

        public void EditInfo(string nome, bool active)
        {
            Nome = nome;
            Active = active;
            Validate();
        }
    }
}
