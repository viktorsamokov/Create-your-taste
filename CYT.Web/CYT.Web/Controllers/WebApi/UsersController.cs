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
using CYT.Web.FileManagement;
using System.IO;
using CYT.Web.Models;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CYT.Web.Controllers.WebApi
{
    public class UsersController : ApiController
    {
        private CytDb db = new CytDb();
        private FileManager fileManager = new FileManager();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private static readonly string success = "You have successfully changed your password";
        private static readonly string mismatch = "The new password and confirmation password do not match";
        private static readonly string incorrectPassword = "Your password is incorrect";

        public UsersController()
        {
        }

        public UsersController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("api/user/{userId:int}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetFullUser(int userId)
        {
            User user = db.Users.Include(r => r.Recipes).Include(f => f.FavoriteRecipes).SingleOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpGet]
        [Route("api/user/authentication")]
        public IHttpActionResult IsAuthenticatedUser()
        {


            List<string> result = new List<string>();
            if (!User.Identity.IsAuthenticated)
            {
                result.Add("False");
                return Ok(result);
            }
            else
            {
                string username = User.Identity.Name;
                IEnumerable<User> user = db.Users.Where(e => e.Username == username);

                if (user.Count() == 0)
                {
                    result.Add("False");
                    return Ok(result);
                }

                return Ok(user);
            }

        }

        [HttpGet]
        [Route("api/administrator/authentication")]
        public IHttpActionResult IsAuthenticatedAdministratorUser()
        {

            List<string> result = new List<string>();
            if (!User.Identity.IsAuthenticated)
            {
                result.Add("False");
                return Ok(result);
            }
            else
            {
                string username = User.Identity.Name;
                IEnumerable<User> user = db.Users.Where(e => e.Username == username && e.UserRole == UserRole.Administrator);

                if (user.Count() == 0)
                {
                    result.Add("False");
                    return Ok(result);
                }

                return Ok(user);
            }

        }

        [HttpPost]
        [Route("api/upload/profile/user/{id:int}")]
        public async Task<IHttpActionResult> UploadUserImage(int id, HttpRequestMessage request)
        {
            User user = db.Users.Find(id);

            string directory = fileManager.GetUserDirectoryPath(id);
            MultipartFormDataStreamProvider provider = new GuidMultipartFormDataStreamProvider(directory);

            FileUploader fileUploader = new FileUploader(request, provider, null);

            FileUploadResult uploadResult = await fileUploader.Upload();

            if (uploadResult.Status != FileUploadStatus.Success)
                return BadRequest(uploadResult.Messages);
            
            string oldFile = fileManager.GetUserFilePath(id, user.ProfileImage);
            fileManager.RemoveFile(oldFile);

            FileInfo fileInfo = fileUploader.GetFileInfo();
            user.ProfileImage = fileManager.GetUserFileUrl(id, fileInfo.Name);

            db.Entry(user).State = EntityState.Modified;

            db.SaveChanges();

            return Ok(user);
        }
        [HttpGet]
        [Route("api/favorites/user/{userId:int}")]
        [ResponseType(typeof(IEnumerable<Recipe>))]
        public IHttpActionResult GetFavoriteRecipes(int userId)
        {
            User user = db.Users.Include(u => u.FavoriteRecipes.Select(s => s.RecipeImages)).Include(u => u.FavoriteRecipes.Select(s => s.User)).SingleOrDefault(us => us.UserId == userId);
            if (user == null)
            {
                return NotFound();
            }
            List<Recipe> recipes = new List<Recipe>();
            if (user.FavoriteRecipes == null)
            {
                return Ok(recipes);
            }
            foreach(Recipe r in user.FavoriteRecipes)
            {
                recipes.Add(r);
            }
            if (recipes == null)
            {
                return NotFound();
            }
            return Ok(recipes);
        }

        [HttpDelete]
        [Route("api/remove/favourite/recipe/{recipeId:int}/{userId:int}")]
        public IHttpActionResult RemoveFavoriteRecipe(int recipeId, int userId)
        {

            User user = db.Users.Include(u => u.FavoriteRecipes).SingleOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound();
            }

            List<Recipe> recipes = new List<Recipe>();

            foreach (Recipe r in user.FavoriteRecipes)
            {
                if (!(r.RecipeId == recipeId))
                {
                    recipes.Add(r);
                }
            }

            user.FavoriteRecipes = recipes;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/favorite/user/{userId:int}/{recipeId:int}")]
        [ResponseType(typeof(User))]
        public IHttpActionResult FavoriteUser(int userId,int recipeId)
        {
            User user = db.Users.Include(u => u.FavoriteRecipes).SingleOrDefault(us => us.UserId == userId);
            if(user==null)
            {
                return NotFound();
            }
            Recipe recipe = db.Recipes.Find(recipeId);
            if(recipe==null)
            {
                return NotFound();
            }
            if (user.FavoriteRecipes == null)
            {
                user.FavoriteRecipes = new List<Recipe>();
            }
            user.FavoriteRecipes.Add(recipe);
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(user);

        }
        [ResponseType(typeof(PasswordStatusMessageViewModel))]
        [HttpPost]
        [Route("api/Users/changeUserPassword")]
        public async Task<IHttpActionResult> ChangeUserPassword(ChangePasswordViewModel model)
        {
            PasswordStatusMessageViewModel status = new PasswordStatusMessageViewModel();
            
            if (!ModelState.IsValid)
            {
                status.Status = mismatch;
                status.StatusType = PasswordStatusMessage.Mismatch;
                return Ok(status);
            }
            
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }

                status.Status = success;
                status.StatusType = PasswordStatusMessage.Success;
                return Ok(status);
            }

            status.Status = incorrectPassword;
            status.StatusType = PasswordStatusMessage.IncorrectPassword;

            return Ok(status);
        }

        // PUT: api/Users/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}