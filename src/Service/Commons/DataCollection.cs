using System.Collections.Generic;
using System.Linq;

namespace Service.Commons
{
    //Clase generica la puede implementar cualquier objeto
    public class DataCollection<T> where T : class
    {
        public bool HasItems
        {
            // Valida si hay registros encontrados
            get
            {
                return Items != null && Items.Any();
            }
        }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
