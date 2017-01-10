using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public class IngredientQuantity
    {
        [Key]
        public int IngredientQuantityId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}