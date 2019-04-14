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

        public ActionResult ViewAllRecipes (int id = 1)
        {
            List<Recipie> recList = new List<Recipie>();
            List<Recipie> newList = new List<Recipie>();
            recList = db.RecipieDB.ToList();
            //this should find the total number of pages, using the decimal to keep decimals until after rounding.
            int totalPages = (int)Math.Ceiling(((decimal)recList.Count) / (decimal)(12));
            

            //Checks to see if the id is a valid number
            if (id < 1)
            {
                id = 1;
            }

            //Checks to see if the id is within number of archive pages.
            else if (id > totalPages)
            {
                //TODO should add an error page for out of range ids
                id = totalPages;
            }

            //this should return the beginning record of a page.  
            int counter = ((id - 1) * 12);

            if (recList.Count > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    newList.Add(recList[counter]);
                    counter++;
                }
            }
            else
            {
                for (int i = 0; i < recList.Count; i++)
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

            ViewBag.Total = totalPages;
            ViewBag.ThisPage = id;

            return View(wholeRec);
            
            
        }

        public ActionResult RecipeTable ()
        {
            List<Recipie> recList = new List<Recipie>();            
            recList = db.RecipieDB.ToList();
            
            ViewBag.Total = recList.Count;

            return View(recList);
        }

        [HttpPost]
        public ActionResult RecipeTable(Recipie rp)
        {
            db.RecipieDB.Attach(rp);
            db.RecipieDB.Remove(rp);
            db.SaveChanges();

            return View();
        }
    }
}