// -----------------------------------------------------------------------------
//  File:        Pizza.cs
//  Description: Model for a Pizza data object.
//
//  Author:      Aaron Bishop
//  Created:     2025-06-30
//  Modified:    2025-06-30 by Aaron Bishop
//
//  Copyright:   (c) 2025 Contoso Inc. All rights reserved.
// -----------------------------------------------------------------------------

namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
}