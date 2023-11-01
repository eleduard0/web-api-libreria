using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace librerias_AESM.Data
{
    public class AppDbInitializer
    {
        //Metodo que agrega datos a nuestra BD
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Titulo= "1st Book Title",
                        Descripcion = "1st Book's Description",
                        IsRead = false,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Genre",
                        Autor = "1st Author",
                        CoverUrl = "https://#",
                        DateAdded = DateTime.Now

                    },
                    new Models.Book()
                    {
                        Titulo = "2nd Book Title",
                        Descripcion = "2nd Book's Description",
                        IsRead = false,
                        Genero = "Genre",
                        Autor = "2nd Author",
                        CoverUrl = "https://#",
                        DateAdded = DateTime.Now

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
