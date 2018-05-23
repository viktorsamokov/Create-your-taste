using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public enum RecipeStatus
    {

        Pending, Approved, Disabled
    }

    public enum RecipeDifficulty
    {
        Easy, Medium, Advanced
    }

    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public bool GlutenFree { get; set; }

        public int PreparationTime { get; set; }

        public string VideoUrl { get; set; }

        public DateTime TimeCreated { get; set; }

        public float Rating { get; set; }

        public RecipeDifficulty Difficulty { get; set; }

        public RecipeStatus RecipeStatus { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("RecipeCategory")]
        public int RecipeCategoryId { get; set; }

        public virtual User User { get; set; }

        public virtual RecipeCategory RecipeCategory { get; set; }

        public virtual ICollection<RecipeImage> RecipeImages { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<RecipeVote> RecipeVotes { get; set; }

        public void recalculateRating()
        {
            float rating = 0;

            foreach(RecipeVote recipeVote in RecipeVotes) {

                rating += (float)recipeVote.VoteValue;
            }

            rating /= RecipeVotes.Count;

            Rating = rating;
        }
    }
}