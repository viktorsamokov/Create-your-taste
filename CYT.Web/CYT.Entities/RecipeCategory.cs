using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public class RecipeCategory
    {
        [Key]
        public int RecipeCategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}