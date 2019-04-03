using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bits_and_Bites.Models
{
    public class Ingredient
    {        
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int RecipieID { get; set; }
    }
}