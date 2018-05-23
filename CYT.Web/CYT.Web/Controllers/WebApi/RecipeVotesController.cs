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
    public class RecipeVotesController : ApiController
    {
        private CytDb db = new CytDb();

        // GET: api/RecipeVotes
        public IQueryable<RecipeVote> GetRecipeVotes()
        {
            return db.RecipeVotes;
        }

        // GET: api/RecipeVotes/5
        [ResponseType(typeof(RecipeVote))]
        public IHttpActionResult GetRecipeVote(int id)
        {
            RecipeVote recipeVote = db.RecipeVotes.Find(id);
            if (recipeVote == null)
            {
                return NotFound();
            }

            return Ok(recipeVote);
        }


        // GET: api/RecipeVotes/5
        [HttpGet]
        [Route("api/recipe/votes/{recipeId:int}/{userId:int}")]
        [ResponseType(typeof(IEnumerable<RecipeVote>))]
        public IHttpActionResult GetUserVote(int recipeId,int userId)
        {
            IEnumerable<RecipeVote> recipeVote = db.RecipeVotes.Where(rv => rv.UserId==userId && rv.RecipeId==recipeId).ToList();

            if (recipeVote == null|| recipeVote.Count()==0)
            {
                return NotFound();
            }

            return Ok(recipeVote);
        }
        // PUT: api/RecipeVotes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipeVote(int id, RecipeVote recipeVote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeVote.RecipeVoteId)
            {
                return BadRequest();
            }

            db.Entry(recipeVote).State = EntityState.Modified;

            

            try
            {
                db.SaveChanges();
                Recipe r = db.Recipes.SingleOrDefault(u => u.RecipeId == recipeVote.RecipeId);

                IEnumerable<RecipeVote> votes = db.RecipeVotes.Where(z => z.RecipeId == z.RecipeId);
                float result = 0;

                foreach (RecipeVote vote in votes)
                {
                    result += (float)vote.VoteValue;
                }

                result /= votes.Count();
                r.Rating = result;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeVoteExists(id))
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

        // POST: api/RecipeVotes
        [ResponseType(typeof(RecipeVote))]
        public IHttpActionResult PostRecipeVote(RecipeVote recipeVote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeVotes.Add(recipeVote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeVote.RecipeVoteId }, recipeVote);
        }

        // DELETE: api/RecipeVotes/5
        [ResponseType(typeof(RecipeVote))]
        public IHttpActionResult DeleteRecipeVote(int id)
        {
            RecipeVote recipeVote = db.RecipeVotes.Find(id);
            if (recipeVote == null)
            {
                return NotFound();
            }

            db.RecipeVotes.Remove(recipeVote);
            db.SaveChanges();

            return Ok(recipeVote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeVoteExists(int id)
        {
            return db.RecipeVotes.Count(e => e.RecipeVoteId == id) > 0;
        }
    }
}