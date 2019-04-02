using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
    public class Ingredient
    {
        int Id { get; set; }
        string IngredientName { get; set; }
        int RecipieID { get; set; }
    }
}