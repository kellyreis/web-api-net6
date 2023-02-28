using api.Infra.Data;
using api.Domain.Produto;

namespace api.EndPoints.CategoriaEndPoints
{
    public class CategoriaGet
    {
        public static string Template => "/categoria";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;
        public static IResult Action(AppDbContext context)
        {
            var categoria = context.Categoria.ToList();

            var response = categoria
                .Select(x => new CategoriaResponse ( x.Id,  x.Nome, x.Active ));

            return Results.Ok(response);
        }
    }




}

