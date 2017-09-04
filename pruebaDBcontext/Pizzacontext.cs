using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Autofac;

namespace pruebaDBcontext
{
    class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredientes { get; set; }
    }
}
