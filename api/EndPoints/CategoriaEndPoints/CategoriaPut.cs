using api.Infra.Data;
using api.Domain.Produto;
using Microsoft.AspNetCore.Mvc;

namespace api.EndPoints.CategoriaEndPoints
{
    public class CategoriaPut
    {
        public static string Template => "/categoria/{id}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;
        public static IResult Action([FromRoute] Guid id, HttpContext http, CategoriaRequest categoriaRequest, AppDbContext context)
        {
            var category = context.Categoria.Where(c => c.Id == id).FirstOrDefault();
            category.Nome = categoriaRequest.Nome;       


            context.SaveChanges();

            return Results.Ok();
        }
    }




}

