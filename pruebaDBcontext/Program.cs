﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Autofac;

namespace pruebaDBcontext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PizzaContext())
            {

                // Obtener nombre de la pizza
                Console.Write("Nombre pizza: ");
                var name = Console.ReadLine();
                Console.Write("Precio: ");
                var price = decimal.Parse(Console.ReadLine());

                // Asignarlo a una pizza
                var pizza = new Pizza { Nombre = name, Precio = price };

                db.Pizzas.Add(pizza);
                db.SaveChanges();

                // Mostrar pizzas
                var query = from b in db.Pizzas
                            orderby b.Nombre
                            select b;

                Console.WriteLine("Todas las pizzas: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Nombre);
                }

                Console.WriteLine("Exit");
                Console.ReadLine();
            }
        }
        
    } 
}

