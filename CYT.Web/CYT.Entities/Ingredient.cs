using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}