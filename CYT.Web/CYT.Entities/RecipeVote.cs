using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public enum VoteValue
    {
        One = 1, Two = 2, Three = 3, Four = 4, Five = 5
    }

    public class RecipeVote
    {
        [Key]
        public int RecipeVoteId { get; set; }

        public VoteValue VoteValue { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}