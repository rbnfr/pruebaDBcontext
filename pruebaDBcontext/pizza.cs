using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaDBcontext
{
    class Pizza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Ingredientes> Ingredientes { get; set; }
        public decimal Precio { get { return this.Precio; } set { this.Precio = CalcularPrecio(Ingredientes);} }
        public string Comentarios { get; set; }        

        public decimal CalcularPrecio(List<Ingredientes> list)
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
