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
using System.Threading.Tasks;
using CYT.Web.FileUpload;
using System.IO;
using CYT.Web.FileManagement;

namespace CYT.Web.Controllers.WebApi
{
    public class RecipesController : ApiController
    {
        private CytDb db = new CytDb();
        private FileManager fileManager = new FileManager();

        // GET: api/Recipes
        public IQueryable<Recipe> GetRecipes()
        {
            return db.Recipes.Include(u => u.RecipeImages).Include(u => u.Ingredients).Include(u => u.RecipeCategory).Include(u => u.RecipeVotes).Include(u => u.User).Where(r => r.RecipeStatus == RecipeStatus.Approved);
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult GetRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null || recipe.RecipeStatus == RecipeStatus.Pending)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // GET: api/Recipes/5
        [HttpGet]
        [Route("api/all/recipes")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetAllRecipes()
        {
            IEnumerable<Recipe> recipes = db.Recipes.Include(u => u.RecipeImages).Include(u => u.Ingredients).Include(u => u.RecipeCategory).Include(u => u.RecipeVotes).Include(u => u.User);
            if (recipes == null )
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpGet]
        [Route("api/user/recipes/{id:int}")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetUserRecipes(int id)
        {
            IEnumerable<Recipe> recipes = db.Recipes.Where(r => r.UserId == id && r.RecipeStatus == RecipeStatus.Approved).Include(u => u.RecipeImages).Include(u => u.User).Include(u => u.RecipeCategory).Include(u => u.Ingredients);
            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpGet]
        [Route("api/user/recipes/admin/{id:int}")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetUserAdminRecipes(int id)
        {
            IEnumerable<Recipe> recipes = db.Recipes.Where(r => r.UserId == id).Include(u => u.RecipeImages).Include(u => u.User).Include(u => u.RecipeCategory).Include(u => u.Ingredients);
            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpGet]
        [Route("api/recipe/{recipeId:int}")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetFullRecipe(int recipeId)
        {
            IEnumerable<Recipe> recipe = db.Recipes.Where(r => r.RecipeId == recipeId && r.RecipeStatus == RecipeStatus.Approved).Include(u => u.RecipeImages).Include(u => u.User).Include(u => u.RecipeCategory).Include(u => u.Ingredients);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        [Route("api/search/recipes/category")]
        //[ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult SearchRecipesCategory(int categoryId, string[] ingridients)
        {

            IEnumerable<Recipe> recipes = db.Recipes.Where(r => r.RecipeCategoryId == categoryId && r.RecipeStatus == RecipeStatus.Approved).Include(u => u.RecipeImages).Include(u => u.User).Include(u => u.RecipeCategory).Include(u => u.RecipeVotes).Include(i => i.Ingredients);
            

            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }

        [HttpPost]
        [Route("api/search/recipes")]
        //[ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult SearchRecipes(string[] ingridients)
        {


            //IEnumerable<Recipe> recipes = db.Recipes.Where(r => r.RecipeId == recipeId && r.RecipeStatus == RecipeStatus.Approved).Include(u => u.RecipeImages).Include(u => u.User).Include(u => u.RecipeCategory).Include(u => u.Ingredients);
            //if (recipes == null)
            //{
            //    return NotFound();
            //}

            return Ok();
        }

        [HttpGet]
        [Route("api/similar/recipes/{recipeId:int}")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetSimilarRecipes(int recipeId)
        {
            Recipe recipe = db.Recipes.Find(recipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            IEnumerable<Recipe> recipes = db.Recipes.Where(u => u.RecipeCategoryId == recipe.RecipeCategoryId && u.RecipeStatus == RecipeStatus.Approved).OrderByDescending(u => u.Rating).Take(3).Include(i => i.RecipeImages).ToList();
            
            if (recipes == null)
            {
                return NotFound();
            }

            return Ok(recipes);
        }



        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            //foreach (Ingredient ingredient in recipe.Ingredients)
            //{
            //    if (ingredient.RecipeId == 0)
            //    {
            //        ingredient.RecipeId = recipe.RecipeId;
            //        db.Entry(ingredient).State = EntityState.Added;
            //    }
            //}

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
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

        [HttpPost]
        [Route("api/upload/recipes/image/{recipeId:int}/{userId:int}")]
        public async Task<IHttpActionResult> UploadRecipeImage(int recipeId, int userId, HttpRequestMessage request)
        {
            RecipeImage image = new RecipeImage();
            string directory = fileManager.GetRecipeDirectoryPath(userId, recipeId);
            MultipartFormDataStreamProvider provider = new GuidMultipartFormDataStreamProvider(directory);

            FileUploader fileUploader = new FileUploader(request, provider, null);

            FileUploadResult uploadResult = await fileUploader.Upload();

            if (uploadResult.Status != FileUploadStatus.Success)
                return BadRequest(uploadResult.Messages);

            FileInfo fileInfo = fileUploader.GetFileInfo();
            

            image.Description = "";
            image.RecipeId = recipeId;
            image.TimeCreated = DateTime.Now;
            image.ImageUrl = fileManager.GetRecipeImageFileUrl(userId, recipeId, fileInfo.Name);

            db.RecipeImages.Add(image);

            db.SaveChanges();
            return Ok(image);
        }

        [HttpPost]
        [Route("api/recipe/update/{recipeId:bool}")]
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult RecipeUpdate(bool recipeId, Recipe recipe)
        {
            Recipe re = db.Recipes.Find(recipe.RecipeId);

            if (recipe == null)
            {
                return NotFound();
            }

            if (recipeId)
            {
                re.RecipeStatus = RecipeStatus.Approved;
            }
            else
                re.RecipeStatus = RecipeStatus.Disabled;


            db.Entry(re).State = EntityState.Modified;

            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult PostRecipe(Recipe recipe)
        {
            User user = db.Users.Single(u => u.Username == User.Identity.Name);

            if(user == null){
                return BadRequest();
            }
            recipe.TimeCreated = DateTime.Now;
            recipe.RecipeImages = new List<RecipeImage>();
            recipe.RecipeVotes = new List<RecipeVote>();
            recipe.Rating = 0;
            recipe.UserId = user.UserId;
            recipe.RecipeStatus = RecipeStatus.Pending;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipe.RecipeId }, recipe);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            db.SaveChanges();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.RecipeId == id) > 0;
        }
    }
}