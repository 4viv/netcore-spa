using Microsoft.EntityFrameworkCore;
using Service.Commons;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Extensions
{
    public static class Paging
    {
        public static async Task<DataCollection<T>> PagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take
        ) where T : class
        {
            //Instanciamos la clase para comenzar a llenar sus valores
            var result = new DataCollection<T>();

            //Total de clientes
            result.Total = await query.CountAsync();
            // Pagina actual
            result.Page = page;

            // Cantidad de paginas que se van a generar
            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(
                    Math.Ceiling(
                        Convert.ToDecimal(result.Total) / take
                    )
                );

                //Traemos los registros
                result.Items = await query.Skip((page - 1) * take)
                                            .Take(take)
                                            .ToListAsync();
            }

            return result;
            // Agregamos un la referencia en el automapper
        }
    }
}
