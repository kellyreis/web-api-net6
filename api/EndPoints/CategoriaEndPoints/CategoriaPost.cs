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
            var categoria = new Categoria(categoriaRequest.Nome,"Teste","Teste");

            if (!categoria.IsValid)
            {           
                return Results.ValidationProblem(categoria.Notifications.ConvertToDetails());
            }

            context.Categoria.Add(categoria);
            context.SaveChanges();

            return Results.Created($"/categoria/{categoria.Id}", categoria.Id);
        }
    }




}

