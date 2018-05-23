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
    public class RecipeImagesController : ApiController
    {
        private CytDb db = new CytDb();

        // GET: api/RecipeImages
        public IQueryable<RecipeImage> GetRecipeImages()
        {
            return db.RecipeImages;
        }

        // GET: api/RecipeImages/5
        [ResponseType(typeof(RecipeImage))]
        public IHttpActionResult GetRecipeImage(int id)
        {
            RecipeImage recipeImage = db.RecipeImages.Find(id);
            if (recipeImage == null)
            {
                return NotFound();
            }

            return Ok(recipeImage);
        }

        // PUT: api/RecipeImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeImage(int id, RecipeImage recipeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeImage.RecipeImageId)
            {
                return BadRequest();
            }

            db.Entry(recipeImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeImageExists(id))
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

        // POST: api/RecipeImages
        [ResponseType(typeof(RecipeImage))]
        public IHttpActionResult PostRecipeImage(RecipeImage recipeImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeImages.Add(recipeImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeImage.RecipeImageId }, recipeImage);
        }

        // DELETE: api/RecipeImages/5
        [ResponseType(typeof(RecipeImage))]
        public IHttpActionResult DeleteRecipeImage(int id)
        {
            RecipeImage recipeImage = db.RecipeImages.Find(id);
            if (recipeImage == null)
            {
                return NotFound();
            }

            db.RecipeImages.Remove(recipeImage);
            db.SaveChanges();

            return Ok(recipeImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeImageExists(int id)
        {
            return db.RecipeImages.Count(e => e.RecipeImageId == id) > 0;
        }
    }
}