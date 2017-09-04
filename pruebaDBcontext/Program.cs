using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace pruebaDBcontext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PizzaContext())
            {
                try
                {

                    // Crear ingredientes
                    var queso =  new Ingredientes { Id = 1, Nombre = "Queso",  Precio = 3 };
                    var tomate = new Ingredientes { Id = 2, Nombre = "Tomate", Precio = 2 };
                    var bacon =  new Ingredientes { Id = 3, Nombre = "Bacon",  Precio = 5 };

                    // Crear lista de ingredientes
                    var ingredients_list = new List<Ingredientes>
                    {
                        queso,
                        bacon,
                        tomate
                    };

                    // Obtener nombre de la pizza
                    Console.Write("Nombre pizza: ");
                    var name = Console.ReadLine();

                    // Obtener lista de ingredientes
                    //
                    //Console.Write("Ingredientes: ");
                    //var ingredients = Console.ReadLine();

                    // Convertir la cadena con los ingredientes en una lista
                    //var ingredients_split = ingredients.Split(',');
                    //Console.WriteLine("Ingredientes_split: "+ingredients_split);
                    //Console.ReadLine();

                    // Crear la lista de ingredientes como objetos
                    //foreach (var ingredient in ingredients_split)
                    //{
                    //    ingredients_list.Add(ingredient);
                    //}
                    //Console.WriteLine("Ingredientes_list: "+ingredients_list);

                    // Asignarlos a una pizza
                    var pizza = new Pizza { Nombre = name, Ingredientes = ingredients_list };
                    db.Pizzas.Add(pizza);
                    db.SaveChanges();

                    // Mostrar pizzas
                    var query = from b in db.Pizzas
                                orderby b.Nombre
                                select b;

                    Console.WriteLine("Todas las pizzas: ");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item.Nombre + " " + item.Precio);
                    }

                    Console.WriteLine("Exit");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    var exception = e.GetType();
                    Console.WriteLine("Exception type: " + exception + " " + e);
                    Console.ReadLine();
                }
                //finally
                //{
                //    Environment.Exit(0);
                //}                
            }
        }        

        
        public class PizzaContext : DbContext
        {
            public DbSet<Pizza> Pizzas { get; set; }
            public DbSet<Ingredientes> Ingredientes { get; set; }
        }
        static Ingredientes? Cast<Ingredientes>(object obj) where Ingredientes : struct
        {
            return obj as Ingredientes?;
        }
    }
}

