using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CYT.Entities;
using CYT.Web.DataContext;

namespace CYT.Web.Controllers.WebApi
{
    public class RecipeCategoriesController : ApiController
    {
        private CytDb db = new CytDb();

        // GET: api/RecipeCategories
        public IQueryable<RecipeCategory> GetRecipeCategories()
        {
            return db.RecipeCategories;
        }

        // GET: api/RecipeCategories/5
        [ResponseType(typeof(RecipeCategory))]
        public IHttpActionResult GetRecipeCategory(int id)
        {
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return NotFound();
            }

            return Ok(recipeCategory);
        }

        // PUT: api/RecipeCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeCategory(int id, RecipeCategory recipeCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeCategory.RecipeCategoryId)
            {
                return BadRequest();
            }

            db.Entry(recipeCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RecipeCategories
        [ResponseType(typeof(RecipeCategory))]
        public IHttpActionResult PostRecipeCategory(RecipeCategory recipeCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeCategories.Add(recipeCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeCategory.RecipeCategoryId }, recipeCategory);
        }

        // DELETE: api/RecipeCategories/5
        [ResponseType(typeof(RecipeCategory))]
        public IHttpActionResult DeleteRecipeCategory(int id)
        {
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);
            if (recipeCategory == null)
            {
                return NotFound();
            }

            db.RecipeCategories.Remove(recipeCategory);
            db.SaveChanges();

            return Ok(recipeCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeCategoryExists(int id)
        {
            return db.RecipeCategories.Count(e => e.RecipeCategoryId == id) > 0;
        }
    }
}