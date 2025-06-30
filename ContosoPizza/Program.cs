// -----------------------------------------------------------------------------
//  File:        Program.cs
//  Description: Boilerplate for ASP.net Core API.
//
//  Author:      Aaron Bishop
//  Created:     2025-06-30
//  Modified:    2025-06-30 by Aaron Bishop
//
//  Copyright:   (c) 2025 Contoso Inc. All rights reserved.
// -----------------------------------------------------------------------------

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
