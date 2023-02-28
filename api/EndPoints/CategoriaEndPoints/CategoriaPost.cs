using api.Infra.Data;
using api.Domain.Produto;

namespace api.EndPoints.CategoriaEndPoints
{
    public class CategoriaPost
    {
        public static string Template => "/categoria";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;
        public static IResult Action(CategoriaRequest categoriaRequest, AppDbContext context)
        {
            var categoria = new Categoria
            {
                Nome = categoriaRequest.Nome,
                CreatedBy = "Teste",
                CreatedOn = DateTime.Now,
                EditedBy = "Teste",
                EditedOn = DateTime.Now,    
            };

            context.Categoria.Add(categoria);
            context.SaveChanges();

            return Results.Created($"/categoria/{categoria.Id}", categoria.Id);
        }
    }




}

