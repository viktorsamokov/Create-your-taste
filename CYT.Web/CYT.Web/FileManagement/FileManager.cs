using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CYT.Web.FileManagement
{
    public class FileManager
    {
        public string GetUserFilePath(int userId, string filepath)
        {
            string[] split = filepath.Split('/');
            string filename = split[split.Length - 1];
            return String.Format("{0}/{1}", GetUserDirectoryPath(userId), filename);
        }

        public string GetUserDirectoryPath(int userId)
        {
            string path = HttpContext.Current.Server.MapPath(String.Format("~/Content/Users/{0}", userId));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
        public string GetUserRecipesDirectoryPath(int userId)
        {
            string path= HttpContext.Current.Server.MapPath(String.Format("~/Content/Users/{0}/Recipes", userId));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }
        public string GetRecipeDirectoryPath(int userId,int recipeId)
        {
            string path= HttpContext.Current.Server.MapPath(String.Format("~/Content/Users/{0}/Recipes/{1}", userId,recipeId));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public string GetRecipeImageFileUrl(int userId, int recipeId, string filename)
        {
            return String.Format("/Content/Users/{0}/Recipes/{1}/{2}", userId, recipeId, filename);
        }

        public string GetUserFileUrl(int userId, string filename)
        {
            return String.Format("/Content/Users/{0}/{1}", userId, filename);
        }

        public bool RemoveFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
                return true;
            }
            return false;
        }

        public bool MoveFile(string from, string to)
        {
            if (File.Exists(from))
            {
                File.Move(from, to);
                return true;
            }
            return false;
        }
    }
}