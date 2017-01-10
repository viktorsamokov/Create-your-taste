using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CYT.Entities
{
    public class RecipeImage
    {
        [Key]
        public int RecipeImageId { get; set; }

        public string Description { get; set; }

        public DateTime TimeCreated { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
