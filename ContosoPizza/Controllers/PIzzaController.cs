// -----------------------------------------------------------------------------
//  File:        PizzaController.cs
//  Description: Handles piza-related HTTP API endpoints.
//
//  Author:      Aaron Bishop
//  Created:     2025-06-30
//  Modified:    2025-06-30 by Aaron Bishop
//
//  Copyright:   (c) 2025 Contoso Inc. All rights reserved.
// -----------------------------------------------------------------------------

using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    /// <summary>
    /// Gets all pizzas from the datastore
    /// </summary>
    /// <remarks>
    /// GET /pizza
    /// </remarks>
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    /// <summary>
    /// Gets a single pizza by id from the datastore
    /// </summary>
    /// <remarks>
    /// GET /pizza/{id}
    /// </remarks>
    /// <param name="id">The ID of the pizza to retrieve</param>
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    /// <summary>
    /// Adds a new pizza to the datastore
    /// </summary>
    /// <param name="pizza">Pizza data to be added</param>
    /// <returns>Pizza that was created.</returns>
    /// <response code="201">Returns the pizza.</response>
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    /// <summary>
    /// Updates an exisiting pizza in the datastore
    /// </summary>
    /// <param name="id">ID of pizza to update</param>
    /// <param name="pizza">New pizza data to update</param>
    /// <returns>Update success or failure</returns>
    /// <response code="204">Pizza was updated</response>
    /// <response code="400">Specified id doesn't match Pizza.Id</response>
    /// <response code="404">Pizza ID does not exist.</response>
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        if(PizzaService.Get(id) is null)
            return NotFound();
    
        PizzaService.Update(pizza);           
    
        return NoContent();
    }

    /// <summary>
    /// Deletes an existing pizza in the datastore
    /// </summary>
    /// <param name="id">ID of pizza to delete</param>
    /// <returns>Delete success or failure</returns>
    /// <response code="204">Pizza was deleted</response>
    /// <responce code="404">Pizza ID does not exist.</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (PizzaService.Get(id) is null)
            return NotFound();
        
        PizzaService.Delete(id);
    
        return NoContent();
    }
}