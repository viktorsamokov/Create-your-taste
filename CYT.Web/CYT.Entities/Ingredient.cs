using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public string IngredientType { get; set; }
    }
}