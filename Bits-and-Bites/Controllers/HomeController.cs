using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bits_and_Bites.Models;

namespace Bits_and_Bites.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int counter = 0;
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogPost()
        {
            return View();
        }

        public ActionResult Static()
        {
            return View();
        }

        public ActionResult Archive()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bits and Bites";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to us.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        public ActionResult AddNewRecipe()
        {
            RecipeAndPictureModel re = new RecipeAndPictureModel();
            return View(re);
        }        

        [HttpPost]
        public ActionResult AddNewRecipe(RecipeAndPictureModel newRecipe)
        {
            Image im = new Image();
            if (newRecipe.CombImage != null)
            {
                im.StoredImage = im.ReturnArray(newRecipe.CombImage);
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    newRecipe.CombImage.InputStream.CopyTo(ms);
                //    array = ms.GetBuffer();
                //    im.StoredImage = array;
                //}
            }
            im.ImageName = newRecipe.CombRecipe.RecipieName;
            im.ImageAlt = newRecipe.CombRecipe.RecipieName;
            db.ImageDB.Add(im);
            newRecipe.CombRecipe.ImageID = im.Id;
            db.RecipieDB.Add(newRecipe.CombRecipe);
            db.SaveChanges();
            return View();
        }

        public ActionResult ViewAllRecipes ()
        {
            List<Recipie> recList = new List<Recipie>();
            List<Recipie> newList = new List<Recipie>();
            recList = db.RecipieDB.ToList();

            if (recList.Count >= 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            else
            {
                for(int i = 0; i < recList.Count; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            List<Bits_and_Bites.Models.Image> imList = new List<Image>();
            List<RecipeWhole> wholeRec = new List<RecipeWhole>();
            foreach (Recipie i in newList)
            {                
                Image result = db.ImageDB.SingleOrDefault(tempIm => tempIm.Id == i.ImageID);
                imList.Add(result);
            }

            for (int i = 0; i < newList.Count; i++)
            {
                RecipeWhole x = new RecipeWhole
                {
                    CombRecipe = newList[i],
                    CombImage = imList[i]
                };
                wholeRec.Add(x);
            }
            return View(wholeRec);
        }
    }
}