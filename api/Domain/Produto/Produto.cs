namespace api.Domain.Produto
{
    public class Produto : Entity
    {
  
        public Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool HasStock { get; set; }
      
    }
}
