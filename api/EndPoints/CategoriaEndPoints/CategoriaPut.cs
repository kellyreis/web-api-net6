using api.Infra.Data;
using api.Domain.Produto;
using Microsoft.AspNetCore.Mvc;

namespace api.EndPoints.CategoriaEndPoints
{
    public class CategoriaPut
    {
        //Informando o tipo do parametro
        public static string Template => "/categoria/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;
        public static IResult Action([FromRoute] Guid id, HttpContext http, CategoriaRequest categoriaRequest, AppDbContext context)
        {
            var category = context.Categoria.Where(c => c.Id == id).FirstOrDefault();

            if (category == null)
                return Results.NotFound();

            category.EditInfo(categoriaRequest.Nome, categoriaRequest.Active);

            if(category.IsValid)
                return Results.ValidationProblem(category.Notifications.ConvertToDetails());

            context.SaveChanges();

            return Results.Ok();
        }
    }




}

