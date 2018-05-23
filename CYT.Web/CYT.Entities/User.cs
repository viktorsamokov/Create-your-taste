using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CYT.Entities
{
    public enum UserRole
    {
        Regular, Administrator
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public bool isBlocked { get; set; }

        public string Email { get; set; }

        public string ProfileImage { get; set; }

        public float Rating { get; set; }

        public UserRole UserRole { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Recipe> FavoriteRecipes { get; set; }
    }
}