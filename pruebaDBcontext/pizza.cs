using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaDBcontext
{
    class pizza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<ingredient> Ingredientes { get; set; }
        public decimal Precio { get; set; }
        public string Comentarios { get; set; }

        public decimal CalcularPrecio(List<ingredient> list)
        {
            decimal Total = 0;
            foreach (var ingredient in list)
            {
                Total += ingredient.Precio;
            }
            return Total;
        }
    }
}
