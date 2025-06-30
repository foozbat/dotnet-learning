// -----------------------------------------------------------------------------
//  File:        PizzaService.cs
//  Description: Simulated in-memory datastore for Pizza "database"
//
//  Author:      Aaron Bishop
//  Created:     2025-06-30
//  Modified:    2025-06-30 by Aaron Bishop
//
//  Copyright:   (c) 2025 Contoso Inc. All rights reserved.
// -----------------------------------------------------------------------------

using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    /// <summary>
    /// Constructor
    /// </summary>
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Cheese Pizza", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Pepperoni Pizza", IsGlutenFree = false }
        };
    }

    /// <summary>
    /// Gets all pizzas in the datastore.
    /// </summary>
    /// <returns>List of pizzas</returns>
    public static List<Pizza> GetAll() => Pizzas;

    /// <summary>
    /// Gets a specific pizza by id.
    /// </summary>
    /// <param name="id">id of pizza to get</param>
    /// <returns>One pizza</returns>
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Adds a pizza to the datastore.
    /// </summary>
    /// <param name="pizza">Pizza data to add.</param>
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    /// <summary>
    /// Deletes a pizza from the datastore.
    /// </summary>
    /// <param name="id"></param>
    public static void Delete(int id)
    {
        var pizza = Get(id);

        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    /// <summary>
    /// Updates an existing pizza in the datastore.
    /// </summary>
    /// <param name="pizza">Pizza data to update.</param>
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}